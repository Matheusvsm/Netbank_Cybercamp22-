using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindPixOutDetailsRequest : BaseRequest
    {
        public new string Method { get => "GetPixOutById"; }
        public long ExternalIdentifier { get; set; }
        public string TaxId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
    }
}