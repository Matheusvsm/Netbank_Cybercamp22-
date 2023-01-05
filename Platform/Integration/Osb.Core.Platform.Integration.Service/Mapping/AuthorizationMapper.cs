using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Auth;
using Osb.Core.Platform.Integration.Util;

namespace Osb.Core.Platform.Integration.Service.Mapping
{
    public static class AuthorizationMapper
    {
        public static Authorization Map(CompanyAuthentication companyAuthentication)
        {
            var authData = RequestCredentialsUtil.GetBasicAuthData(
                companyAuthentication.UserName,
                companyAuthentication.Password
            );

            return new Authorization
            {
                Data = authData,
                Type = AuthType.Basic
            };
        }
    }
}