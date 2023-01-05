using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using System;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Service
{

    public class NotificationService : INotificationService
    {
        private readonly SendNotificationMapper _mapper;
        private readonly INotificationRepositoryFactory _notificationRepositoryFactory;
        private readonly INotificationServiceFactory _notificationServiceFactory;
        private readonly Settings _settings;
        private IConnectionFactory _connectionFactory;

        public NotificationService(INotificationRepositoryFactory notificationRepositoryFactory, INotificationServiceFactory notificationServiceFactory, Settings settings, IConnectionFactory connectionFactory)
        {
            _mapper = new SendNotificationMapper();
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _notificationServiceFactory = notificationServiceFactory;
            _settings = settings;
            _connectionFactory = connectionFactory;
        }

        public void Save(string mail, string phoneNumber, string subject, string content, long companyId, SendType? sendType = null, TransactionScope transactionScope = null)
        {

            SmsNotification sendSms = SmsNotification.Create(
                                   _settings.UserDefault,
                                   companyId,
                                   phoneNumber,
                                   content
                                );

            MailNotification sendMail = MailNotification.Create(
                                 _settings.UserDefault,
                                 companyId,
                                 mail,
                                 subject,
                                 content
                              );

            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();

            switch (sendType)
            {
                case SendType.Mail:
                    notificationRepository.Save(sendMail, transactionScope);
                    break;
                case SendType.Sms:
                    notificationRepository.Save(sendSms, transactionScope);
                    break;
                default:
                    notificationRepository.Save(sendMail, transactionScope);
                    notificationRepository.Save(sendSms, transactionScope);
                    break;
            }
        }

        public void SendSms(SmsNotification smsNotification)
        {
            IntegrationService.INotificationService notificationIntegrationService = _notificationServiceFactory.Create();
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();

            try
            {
                SendSmsRequest sendSmsRequest = new SendSmsRequest();
                sendSmsRequest = _mapper.Map<SendSmsRequest>(SendType.Sms, smsNotification.PhoneTo, null, null, smsNotification.Content, smsNotification.CompanyId);
                notificationIntegrationService.SendSms(sendSmsRequest);

                smsNotification.SendStatus = SendStatus.Sent;
                notificationRepository.Update(smsNotification);
            }
            catch (Exception)
            {
                smsNotification.Attempts += 1;
                if (smsNotification.Attempts >= _settings.Attempts)
                    smsNotification.SendStatus = SendStatus.Error;

                notificationRepository.Update(smsNotification);
            }

        }

        public void SendMail(MailNotification mailNotification)
        {
            IntegrationService.INotificationService notificationIntegrationService = _notificationServiceFactory.Create();
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();

            try
            {
                SendMailRequest sendMailRequest = new SendMailRequest();
                sendMailRequest = _mapper.Map<SendMailRequest>(SendType.Mail, null, mailNotification.MailTo, mailNotification.Subject, mailNotification.Content, mailNotification.CompanyId);
                notificationIntegrationService.SendMail(sendMailRequest);

                mailNotification.SendStatus = SendStatus.Sent;
                notificationRepository.Update(mailNotification);
            }
            catch (Exception)
            {
                mailNotification.Attempts += 1;
                if (mailNotification.Attempts >= _settings.Attempts)
                    mailNotification.SendStatus = SendStatus.Error;

                notificationRepository.Update(mailNotification);
            }

        }

        public void SendPushNotification(PushNotification pushNotification)
        {
            IntegrationService.INotificationService notificationIntegrationService = _notificationServiceFactory.Create();
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
            Device device = notificationRepository.GetDeviceByUserIdAndCompanyId(pushNotification.UserId, pushNotification.CompanyId);

            SendPushNotificationRequest sendPushNotificationRequest = new SendPushNotificationRequest();
            sendPushNotificationRequest = _mapper.Map(device.Token, pushNotification.Title, pushNotification.Body);
            notificationIntegrationService.SendPushNotification(sendPushNotificationRequest);

            pushNotification.Status = PushNotificationStatus.Sent;
            pushNotification.SendDate = DateTime.Now;

            notificationRepository.Update(pushNotification);
        }

        public IEnumerable<SmsNotification> FindSendSmsNotificationBySendStatus(SendStatus sendStatus)
        {
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
            IEnumerable<SmsNotification> smsList = notificationRepository.FindSmsListBySendStatus(sendStatus);

            return smsList;
        }

        public void Update(SmsNotification smsNotification)
        {
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
            notificationRepository.Update(smsNotification);
        }

        public IEnumerable<MailNotification> FindSendMailNotificationBySendStatus(SendStatus sendStatus)
        {
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
            IEnumerable<MailNotification> mailList = notificationRepository.FindMailListBySendStatus(sendStatus);

            return mailList;
        }

        public void Update(MailNotification mailNotification)
        {
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
            notificationRepository.Update(mailNotification);
        }

        public IEnumerable<PushNotification> FindPushNotificationByStatus(PushNotificationStatus status)
        {
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
            IEnumerable<PushNotification> pushNotificationList = notificationRepository.FindPushNotificationListByStatus(status);

            return pushNotificationList;
        }

        public void Update(PushNotification pushNotification)
        {
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
            notificationRepository.Update(pushNotification);
        }
    }
}