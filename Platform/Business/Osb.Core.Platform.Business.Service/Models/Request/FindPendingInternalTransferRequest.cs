namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindPendingInternalTransferRequest : BaseRequest
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string VerificationCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}