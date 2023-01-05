using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class GenerateHashCodeRequest : BaseRequest
    {
        public new string Method { get => "GenerateQRCode"; }
        public string AccountKey { get; set; }
        public string TaxId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string Identifier { get; set; }
        public decimal Value { get; set; }
    }
}