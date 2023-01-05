using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;
using AuthRequest = Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class AuthorizationTokenMapper
    {
        public AuthRequest.GenerateAuthorizationTokenRequest Map(GenerateAuthorizationTokenRequest generateAuthorizationTokenRequest, object companyId)
        {
            return new AuthRequest.GenerateAuthorizationTokenRequest
            {
                UserId = generateAuthorizationTokenRequest.UserId,
                AccountId = generateAuthorizationTokenRequest.AccountId,
                TaxId = generateAuthorizationTokenRequest.TaxId != null ? Formatter.RemoveMaskFromTaxId(generateAuthorizationTokenRequest.TaxId) : null,
                CompanyId = (long)companyId,
                PhoneNumber = generateAuthorizationTokenRequest.PhoneNumber != null ? Formatter.RemoveMaskFromPhoneNumber(generateAuthorizationTokenRequest.PhoneNumber) : null,
                Mail = generateAuthorizationTokenRequest.Mail,
                SendType = generateAuthorizationTokenRequest.SendType
            };
        }

        public AuthRequest.ValidateAuthorizationTokenRequest Map(ValidateAuthorizationTokenRequest validateAuthorizationTokenRequest)
        {
            return new AuthRequest.ValidateAuthorizationTokenRequest
            {
                Code = validateAuthorizationTokenRequest.Code,
                UserId = validateAuthorizationTokenRequest.UserId,
                AccountId = validateAuthorizationTokenRequest.AccountId,
                TaxId = validateAuthorizationTokenRequest.TaxId != null ? Formatter.RemoveMaskFromTaxId(validateAuthorizationTokenRequest.TaxId) : null
            };
        }
    }
}