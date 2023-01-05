using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class PendingInternalTransferRequest : BaseRequest
    {
        public new string Method { get => "GeneratePendingInternalTransferBySMS"; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public decimal Value { get; set; }
        public string Identifier { get; set; }
        public string FromTaxNumber { get; set; }
        public string FromBank { get; set; }
        public string FromBankBranch { get; set; }
        public string FromBankAccount { get; set; }
        public string FromBankAccountDigit { get; set; }
    }
}