using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Webhook.Api.Models.Request;
using Osb.Core.Webhook.Api.Util;
using AuthService = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Webhook.Api.Mapping
{
    public class UserMapper
    {
        public AuthService.UserWebhookRequest Map(UserWebhookRequest userWebHookRequest)
        {
            return new AuthService.UserWebhookRequest
            {
                CompanyId = userWebHookRequest.BusinessUnitId,
                Login = userWebHookRequest.UserTaxNumber,
                Name = userWebHookRequest.Name,
                Mail = userWebHookRequest.Email,
                PhoneNumber = Formatter.RemoveMaskFromPhoneNumber(userWebHookRequest.CellPhone),
                EventType = (EventType)userWebHookRequest.EventType,
                LockedUser = userWebHookRequest.LockedUser,
                AccountKeyList = userWebHookRequest.AccountKeyList
            };
        }
    }
}