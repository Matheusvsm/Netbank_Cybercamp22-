using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Result;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Service.Interfaces
{
    public interface IUserService
    {
        void UserWebhookHandler(UserWebhookRequest userWebhookRequest);
        void Save(UserWebhookRequest userWebhookRequest);
        void Update(UserWebhookRequest userWebhookRequest);
        void Delete(UserWebhookRequest userWebhookRequest);
        void SaveUserInformation(UserInformationRequest userInformationRequest);
        UserInformationResult FindUserInformation(FindUserInformationRequest findUserInformationRequest);
        void UpdateUserInformation(UserInformationRequest updateUserInformationRequest);
        void ChangePassword(ChangePasswordRequest changePasswordRequest);
        UserContactsResult FindUserContactsByLogin(FindUserContactsByLoginRequest findUserInformationByLoginRequest);
        void ResetPassword(ResetPasswordRequest resetPasswordRequest);
        void UpdateUserTerms(UpdateUserTermsRequest updateUserTermsRequest);
    }
}