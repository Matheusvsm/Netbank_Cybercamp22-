using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class NewAccountAddress : BaseEntity
    {
        public long NewAccountAddressId { get; set;}
        public long NewAccountId { get; set;}
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
		public string State { get; set; }
		public AddressType AddressType { get; set; }
        public string Country { get; set; }
		public string Complement { get; set; }

        public static NewAccountAddress Create(long newAccountId, string addressLine, string addressLine2, string zipCode, string neighborhood, string cityCode, string cityName, string state,
            AddressType addressType, string country, string complement, long userId)
        {
            return new NewAccountAddress{
                NewAccountId = newAccountId,
                AddressLine = addressLine,
                AddressLine2 = addressLine2,
                ZipCode = zipCode,
                Neighborhood = neighborhood,
                CityCode = cityCode,
                CityName = cityName,
                State = state,
                AddressType = addressType,
                Country = country,
                Complement = complement,
                CreationUserId = userId
            };
        }
    }
}