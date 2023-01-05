using System;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class SenderMapper
    {
        public T Map<T>(SendType sendType, string password, long companyId, UserInformation userInformation, string subject = null)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            if (sendType.Equals(SendType.Mail))
            {
                SendMailRequest sendMailRequest = new SendMailRequest()
                {
                    CompanyId = companyId,
                    Subject = subject,
                    To = userInformation.Mail,
                    Content = Convert.ToString(password)
                };

                obj = (T)Convert.ChangeType(sendMailRequest, typeof(T));
            }
            else if (sendType.Equals(SendType.Sms))
            {
                SendSmsRequest sendSmsRequest = new SendSmsRequest()
                {
                    CompanyId = companyId,
                    To = userInformation.PhoneNumber,
                    Content = Convert.ToString(password)
                };

                obj = (T)Convert.ChangeType(sendSmsRequest, typeof(T));
            }

            return (T)obj;
        }
    }
}