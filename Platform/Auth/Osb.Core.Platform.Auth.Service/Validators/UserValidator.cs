using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Auth.Util.Resources.UserExcMsg;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;
using System;

namespace Osb.Core.Platform.Auth.Service.Validators
{
    public class UserValidator
    {
        public void Validate(UserInformationRequest userInformationRequest)
        {
            if (string.IsNullOrEmpty(userInformationRequest.Name))
                throw new OsbAuthException(UserExcMsg.EXC0001);

            if (string.IsNullOrEmpty(userInformationRequest.Mail))
                throw new OsbAuthException(UserExcMsg.EXC0002);

            if (string.IsNullOrEmpty(userInformationRequest.PhoneNumber))
                throw new OsbAuthException(UserExcMsg.EXC0003);
        }

        public void Validate(ChangePasswordRequest changePasswordRequest)
        {
            if (changePasswordRequest.UserId == 0)
                throw new OsbAuthException(UserExcMsg.EXC0004);

            if ((string.IsNullOrEmpty(changePasswordRequest.NewPassword) ||
                    string.IsNullOrEmpty(changePasswordRequest.ConfirmationNewPassword)) ||
                        !changePasswordRequest.NewPassword.Equals(changePasswordRequest.ConfirmationNewPassword))
                throw new OsbAuthException(UserExcMsg.EXC0005);
        }

        public void Validate(ResetPasswordRequest resetPasswordRequest)
        {
            if (string.IsNullOrEmpty(resetPasswordRequest.Login))
                throw new OsbAuthException(UserExcMsg.EXC0006);

            if (!Enum.IsDefined<SendType>(resetPasswordRequest.SendType))
                throw new OsbAuthException(UserExcMsg.EXC0007);
        }

        public void Validate(FindUserContactsByLoginRequest findUserContactsByLoginRequest)
        {
            if (string.IsNullOrEmpty(findUserContactsByLoginRequest.Login))
                throw new OsbAuthException(UserExcMsg.EXC0006);
        }

        public void Validate(UserWebhookRequest userWebhookRequest)
        {
            if (string.IsNullOrEmpty(userWebhookRequest.Login))
                throw new OsbAuthException(UserExcMsg.EXC0006);
        }

        public void Validate(UpdateUserTermsRequest updateUserTermsRequest)
        {
            if (updateUserTermsRequest.UserId == 0)
                throw new OsbAuthException(UserExcMsg.EXC0004);

            if (String.IsNullOrEmpty(updateUserTermsRequest.Login))
                throw new OsbAuthException(UserExcMsg.EXC0006);
        }
    }
}
