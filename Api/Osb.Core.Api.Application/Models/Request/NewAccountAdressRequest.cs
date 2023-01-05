using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class NewAccountAddressRequest
    {
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
    }
}