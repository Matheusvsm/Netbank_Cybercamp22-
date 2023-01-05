namespace Osb.Core.Platform.Auth.Service.Models.Result
{
    public class AuthenticateResult
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string TaxId { get; set; }
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
        public string Token { get; set; }
        public bool IsFirstAccess { get; set; }
        public string TokenAccess { get; set; }
        public bool AcceptedTerms { get; set; }
    }
}