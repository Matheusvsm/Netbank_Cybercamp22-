using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class GenerateStaticPixQRCodeRequest: BaseRequest
    {
        public new string Method { get => "GenerateStaticPixQRCode"; }
        public decimal? PrincipalValue { get; set; }
        public string PixKey { get; set; }
        public string TaxNumber { get; set; }
        public PixAddress Address { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string AdditionalData { get; set; }
        public PixTransactionPurpose? PixTransactionPurpose { get; set; }
    }
}