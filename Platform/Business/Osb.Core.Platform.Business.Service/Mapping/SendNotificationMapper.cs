using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class SendNotificationMapper
    {
        public T Map<T>(SendType sendType, string phoneNumber, string mail, string subject, string content, long companyId)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            if (sendType.Equals(SendType.Mail))
            {
                SendMailRequest sendMailRequest = new SendMailRequest()
                {
                    CompanyId = companyId,
                    Subject = subject,
                    To = mail,
                    Content = content
                };

                obj = (T)Convert.ChangeType(sendMailRequest, typeof(T));
            }
            else if (sendType.Equals(SendType.Sms))
            {
                SendSmsRequest sendSmsRequest = new SendSmsRequest()
                {
                    CompanyId = companyId,
                    To = phoneNumber,
                    Content = content
                };

                obj = (T)Convert.ChangeType(sendSmsRequest, typeof(T));
            }

            return (T)obj;
        }

        public IntegrationRequest.SendPushNotificationRequest Map(string token, string title, string body)
        {
            return new IntegrationRequest.SendPushNotificationRequest
            {
                Token = token,
                Title = title,
                Body = body,
            };
        }
    }
}