using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Util.Resources;
using Osb.Core.Platform.Auth.Util.Resources.AuthorizationTokenExcMsg;

namespace Osb.Core.Platform.Auth.Service.Validators
{
    public class AuthorizationTokenValidator
    {
        public void Validate(ValidateAuthorizationTokenRequest validateTokenRequest)
        {
            if (string.IsNullOrEmpty(validateTokenRequest.Code))
                throw new OsbAuthException(AuthorizationTokenExcMsg.EXC0001);
        }

        public void Validate(GenerateAuthorizationTokenRequest authorizationTokenRequest)
        {
            if ((authorizationTokenRequest.AccountId == 0 && authorizationTokenRequest.UserId == 0) && string.IsNullOrEmpty(authorizationTokenRequest.PhoneNumber))
                throw new OsbAuthException(AuthorizationTokenExcMsg.EXC0002);
        }
    }
}