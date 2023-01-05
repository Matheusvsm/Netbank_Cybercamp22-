using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class UserInformation : BaseEntity
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public string Reference { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public static UserInformation Create(long userId, string name = null, string mail = null, 
                                             string phoneNumber = null, string zipCode = null, string Street = null, 
                                             string number = null, string district = null, string complement = null,string reference = null, 
                                             string city = null, string state = null, string country = null)
        {
            return new UserInformation
            {
                UserId = userId,
                Name = name,
                Mail = mail,
                PhoneNumber = phoneNumber,
                ZipCode = zipCode,
                Street = Street,
                Number = number,
                District = district,
                Complement = complement,
                Reference = reference,
                City = city,
                State = state,
                Country = country
            };
        }
    }
}