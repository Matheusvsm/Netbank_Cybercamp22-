using Osb.Core.Platform.Business.Entity.Models;
using AuthRequest = Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;
using System.Collections.Generic;

namespace Osb.Core.Workers.UserHook.Generate.Service.Mapping
{
    public class Mapper
    {
        public AuthRequest.UserWebhookRequest Map(LimitedAccount limitedAccount)
        {
            List<string> accountKeyList = new List<string>();
            accountKeyList.Add(limitedAccount.AccountKey);

            return new AuthRequest.UserWebhookRequest
            {
                CompanyId = limitedAccount.CompanyId,
                Login = limitedAccount.TaxId,
                Name = limitedAccount.Name,
                Mail = limitedAccount.Mail,
                PhoneNumber = limitedAccount.PhoneNumber,
                EventType = EventType.Creation,
                AccountKeyList = accountKeyList,
                Password = limitedAccount.Password,
                Salt = limitedAccount.Salt
            };
        }
    }
}