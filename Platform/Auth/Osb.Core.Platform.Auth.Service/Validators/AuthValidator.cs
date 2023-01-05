using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Util.Resources.AuthExcMsg;

namespace Osb.Core.Platform.Auth.Service.Validators
{
    public class AuthValidator
    {
        public void Validate(AuthenticateRequest userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.Login) && string.IsNullOrEmpty(userRequest.TokenAccess))
                throw new OsbAuthException(AuthExcMsg.EXC0001);

            if (string.IsNullOrEmpty(userRequest.Password))
                throw new OsbAuthException(AuthExcMsg.EXC0002);
        }
    }
}