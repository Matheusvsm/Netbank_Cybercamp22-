using System;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;
using AuthRequest = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class UserInformationMapper
    {
        public AuthRequest.UserInformationRequest Map(UserInformationRequest userInformationRequest)
        {
            return new AuthRequest.UserInformationRequest
            {
                UserId = userInformationRequest.UserId,
                AccountId = userInformationRequest.AccountId,
                Name = userInformationRequest.Name,
                Mail = userInformationRequest.Mail,
                PhoneNumber = userInformationRequest.PhoneNumber,
                ZipCode = userInformationRequest.ZipCode,
                Street = userInformationRequest.Street,
                Number = userInformationRequest.Number,
                District = userInformationRequest.District,
                Complement = userInformationRequest.Complement,
                Reference = userInformationRequest.Reference,
                City = userInformationRequest.City,
                State = userInformationRequest.State,
                Country = userInformationRequest.Country
            };
        }

        public AuthRequest.FindUserInformationRequest Map(FindUserInformationRequest findUserInformationRequest)
        {
            return new AuthRequest.FindUserInformationRequest
            {
                UserId = findUserInformationRequest.UserId
            };
        }

        public AuthRequest.ChangePasswordRequest Map(ChangePasswordRequest changePasswordRequest)
        {
            return new AuthRequest.ChangePasswordRequest
            {
                UserId = changePasswordRequest.UserId,
                CurrentPassword = changePasswordRequest.CurrentPassword,
                NewPassword = changePasswordRequest.NewPassword,
                ConfirmationNewPassword = changePasswordRequest.ConfirmationNewPassword
            };

        }

        public AuthRequest.FindUserContactsByLoginRequest Map(FindUserContactsByLoginRequest findUserContactsByLoginRequest)
        {
            return new AuthRequest.FindUserContactsByLoginRequest
            {
                Login = Formatter.RemoveMaskFromTaxId(findUserContactsByLoginRequest.Login)
            };
        }

        public AuthRequest.ResetPasswordRequest Map(ResetPasswordRequest resetPasswordRequest, object companyId)
        {
            return new AuthRequest.ResetPasswordRequest
            {
                Login = Formatter.RemoveMaskFromTaxId(resetPasswordRequest.Login),
                SendType = resetPasswordRequest.SendType,
                CompanyId = (long)companyId
            };
        }

        public AuthRequest.UpdateUserTermsRequest Map(UpdateUserTermsRequest updateUserTermsRequest, object companyId)
        {
            return new AuthRequest.UpdateUserTermsRequest
            {
                UserId = updateUserTermsRequest.UserId,
                Login = Formatter.RemoveMaskFromTaxId(updateUserTermsRequest.Login),
                CompanyId = (long)companyId
            };
        }
    }
}