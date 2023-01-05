using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Service.Models.Result;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class AuthMapper
    {
        public AuthenticateResult Map(User user, string token, string tokenTaxId, UserInformation userInformation = null)
        {
            return new AuthenticateResult
            {
                UserId = user.UserId,
                Name = userInformation != null ? userInformation.Name : null,
                Mail = userInformation != null ? userInformation.Mail : null,
                TaxId = user.Login,
                PhoneNumber = userInformation != null ? userInformation.PhoneNumber : null,
                ZipCode = userInformation != null ? userInformation.ZipCode : null,
                Street = userInformation != null ? userInformation.Street : null,
                Number = userInformation != null ? userInformation.Number : null,
                District = userInformation != null ? userInformation.District : null,
                Complement = userInformation != null ? userInformation.Complement : null,
                Reference = userInformation != null ? userInformation.Reference : null,
                City = userInformation != null ? userInformation.City : null,
                State = userInformation != null ? userInformation.State : null,
                Country = userInformation != null ? userInformation.Country : null,
                Token = token,
                IsFirstAccess = user.IsFirstAccess,
                TokenAccess = tokenTaxId,
                AcceptedTerms = user.AcceptedTerms
            };
        }
    }
}