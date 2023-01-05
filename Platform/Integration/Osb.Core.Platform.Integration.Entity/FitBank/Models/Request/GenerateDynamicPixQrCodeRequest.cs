using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class GenerateDynamicPixQrCodeRequest : BaseRequest
    {
        public new string Method { get => "GenerateDynamicPixQRCode"; }
        public string PixKey { get; set; }
        public string TaxId { get; set; }
        public string PayerTaxId { get; set; }
        public string PayerName { get; set; }
        public decimal Value { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public PixAddress Address { get; set; }
        public ChangeType ChangeType { get; set; }
    }
}