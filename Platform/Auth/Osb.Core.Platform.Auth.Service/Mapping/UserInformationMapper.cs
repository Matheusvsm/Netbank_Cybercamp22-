using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Service.Models.Result;
using Osb.Core.Platform.Common.Util;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class UserInformationMapper : Mapper
    {
        public UserInformationResult Map(UserInformation userInformation)
        {
            return new UserInformationResult
            {
                Name = userInformation.Name,
                Mail = userInformation.Mail,
                PhoneNumber = userInformation.PhoneNumber,
                ZipCode = userInformation.ZipCode,
                Street = userInformation.Street,
                Number = userInformation.Number,
                District = userInformation.District,
                Complement = userInformation.Complement,
                Reference = userInformation.Reference,
                City = userInformation.City,
                State = userInformation.State,
                Country = userInformation.Country
            };
        }

        public UserContactsResult ContactMap(UserInformation userInformation)
        {
            return new UserContactsResult
            {
                Mail = Utility.MaskEmail(userInformation.Mail),
                PhoneNumber = Utility.MaskPhone(userInformation.PhoneNumber)
            };
        }
    }
}