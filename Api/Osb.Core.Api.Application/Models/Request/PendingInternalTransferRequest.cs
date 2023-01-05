namespace Osb.Core.Api.Application.Models.Request
{
    public class PendingInternalTransferRequest : BaseRequest
    {
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public decimal Value { get; set; }
    }
}