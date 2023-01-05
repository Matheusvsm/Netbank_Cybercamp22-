namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class PendingInternalTransferRequest : BaseRequest
    {
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public decimal Value { get; set; }
    }
}