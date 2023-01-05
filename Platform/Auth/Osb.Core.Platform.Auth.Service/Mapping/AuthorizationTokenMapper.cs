using System;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Common.Util.Security;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class AuthorizationTokenMapper
    {
        public AuthorizationToken Map(long userId, long code, long expirationTime)
        {
            string salt = SHA512Provider.GenerateSalt();

            return new AuthorizationToken
            {
                UserId = userId,
                Code = SHA512Provider.Encrypt(Convert.ToString(code), salt),
                Salt = salt,
                ExpirationDate = DateTime.Now.AddSeconds(expirationTime),
                Status = AuthorizationTokenStatus.Active,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }

        public AuthorizationToken Map(string value, long code, long expirationTime)
        {
            string salt = SHA512Provider.GenerateSalt();

            return new AuthorizationToken
            {
                UserId = default(long),
                TaxId = value,
                Code = SHA512Provider.Encrypt(Convert.ToString(code), salt),
                Salt = salt,
                ExpirationDate = DateTime.Now.AddSeconds(expirationTime),
                Status = AuthorizationTokenStatus.Active,
                CreationUserId = default(long),
                UpdateUserId = default(long)
            };
        }

        public AuthorizationToken Map(string code)
        {
            return new AuthorizationToken
            {
                Code = code,
                Status = AuthorizationTokenStatus.Authorized
            };
        }

        public T Map<T>(SendType sendType, long code, long accountId, UserInformation userInformation)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            if (sendType.Equals(SendType.Mail))
            {
                SendMailRequest sendMailRequest = new SendMailRequest()
                {
                    AccountId = accountId,
                    Subject = "Token",
                    To = userInformation.Mail,
                    Content = Convert.ToString(code)
                };

                obj = (T)Convert.ChangeType(sendMailRequest, typeof(T));
            }
            else if (sendType.Equals(SendType.Sms))
            {
                SendSmsRequest sendSmsRequest = new SendSmsRequest()
                {
                    AccountId = accountId,
                    To = userInformation.PhoneNumber,
                    Content = Convert.ToString(code)
                };

                obj = (T)Convert.ChangeType(sendSmsRequest, typeof(T));
            }

            return (T)obj;
        }

        public T Map<T>(SendType sendType, long code, long companyId, string sendValue)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            if (sendType.Equals(SendType.Mail))
            {
                SendMailRequest sendMailRequest = new SendMailRequest()
                {
                    CompanyId = companyId,
                    Subject = "Token",
                    To = sendValue,
                    Content = Convert.ToString(code)
                };

                obj = (T)Convert.ChangeType(sendMailRequest, typeof(T));
            }
            else if (sendType.Equals(SendType.Sms))
            {
                SendSmsRequest sendSmsRequest = new SendSmsRequest()
                {
                    CompanyId = companyId,
                    To = sendValue,
                    Content = Convert.ToString(code)
                };

                obj = (T)Convert.ChangeType(sendSmsRequest, typeof(T));
            }

            return (T)obj;
        }
    }
}