using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Common;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using FirebaseAdmin.Messaging;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class NotificationService : INotificationService
    {
        public readonly NotificationMapper _mapper = new NotificationMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public NotificationService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public void SendMail(SendMailRequest sendMailRequest)
        {
            CompanyAuthentication companyAuthentication = new CompanyAuthentication();

            if (!sendMailRequest.AccountId.Equals(default(long)))
            {
                companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                  sendMailRequest.AccountId,
                  _companyAuthenticationRepositoryFactory,
                  _settings.AesKey,
                  _settings.AesIV
              );
            }
            else
            {
                companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByCompanyId(
                  sendMailRequest.CompanyId,
                  _companyAuthenticationRepositoryFactory,
                  _settings.AesKey,
                  _settings.AesIV
              );
            }

            ExternalRequest externalRequest = _mapper.Map(sendMailRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, sendMailRequest.UserId);

            ExceptionResponse exceptionResponse = _mapper.Map<ExceptionResponse>(externalResponse.Data);
            if (!exceptionResponse.Status)
                throw new OsbIntegrationException(exceptionResponse.Message);
        }

        public void SendSms(SendSmsRequest sendSmsRequest)
        {
            CompanyAuthentication companyAuthentication = new CompanyAuthentication();

            if (!sendSmsRequest.AccountId.Equals(default(long)))
            {
                companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                  sendSmsRequest.AccountId,
                  _companyAuthenticationRepositoryFactory,
                  _settings.AesKey,
                  _settings.AesIV
              );
            }
            else
            {
                companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByCompanyId(
                  sendSmsRequest.CompanyId,
                  _companyAuthenticationRepositoryFactory,
                  _settings.AesKey,
                  _settings.AesIV
              );
            }

            ExternalRequest externalRequest = _mapper.Map(sendSmsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, sendSmsRequest.UserId);

            ExceptionResponse exceptionResponse = _mapper.Map<ExceptionResponse>(externalResponse.Data);
            if (!exceptionResponse.Status)
                throw new OsbIntegrationException(exceptionResponse.Message);
        }

        public void SendPushNotification(SendPushNotificationRequest sendPushNotificationRequest)
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile(_settings.PushNotificationCredentialPath),
                });
            }

            var message = new Message()
            {
                Notification = new Notification()
                {
                    Title = sendPushNotificationRequest.Title,
                    Body = sendPushNotificationRequest.Body
                },

                Android = new AndroidConfig()
                {
                    Notification = new AndroidNotification()
                    {
                        Title = sendPushNotificationRequest.Title,
                        Body = sendPushNotificationRequest.Body
                    }
                },
                Token = sendPushNotificationRequest.Token,
            };

            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
        }
    }
}