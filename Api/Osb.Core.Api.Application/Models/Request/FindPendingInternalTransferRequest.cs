namespace Osb.Core.Api.Application.Models.Request
{
    public class FindPendingInternalTransferRequest : BaseRequest
    {
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string VerificationCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}