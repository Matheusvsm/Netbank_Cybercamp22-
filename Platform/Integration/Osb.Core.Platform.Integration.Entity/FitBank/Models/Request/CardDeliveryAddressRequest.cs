namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{

public class CardDeliveryAddressRequest
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Reference { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}