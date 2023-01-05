using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class NotificationMapper : Mapper
    {
        public ExternalRequest Map(SendMailRequest sendMailRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                sendMailRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = sendMailRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    To = sendMailRequest.To,
                    Subject = sendMailRequest.Subject,
                    Content = sendMailRequest.Content,
                }
            };
        }

        public ExternalRequest Map(SendSmsRequest sendSmsRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                sendSmsRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = sendSmsRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    To = sendSmsRequest.To,
                    Content = sendSmsRequest.Content,
                }
            };
        }
        public SendPushNotificationRequest Map(string token, string title, string body)
        {
            return new SendPushNotificationRequest
            {
                Token = token,
                Title = title,
                Body = body,
            };
        }
    }
}