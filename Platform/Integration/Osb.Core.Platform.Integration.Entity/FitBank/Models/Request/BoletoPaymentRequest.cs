using System;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class BoletoPaymentRequest : BaseRequest
    {
        public new string Method { get => "GenerateBoletoOut"; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverTaxId { get; set; }
        public string PayerName { get; set; }
        public string PayerTaxId { get; set; }
        public string Barcode { get; set; }
        public decimal PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal DiscountValue { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
    }
}