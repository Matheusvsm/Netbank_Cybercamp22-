using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindPendingInternalTransferRequest : BaseRequest
    {
        public new string Method { get => "GetPendingInternalTransfer"; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string VerificationCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}