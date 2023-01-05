using System;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindBoletoInfoResult
    {
        public string ReceiverTaxId { get; set; }
        public string ReceiverName { get; set; }
        public string PayerTaxId { get; set; }
        public string PayerName { get; set; }
        public decimal PaymentValue { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal FineValue { get; set; }
        public string DigitableLine { get; set; }
        public string Barcode { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string ConcessionaireName { get; set; }
        public string ConcessionaireCode { get; set; }
    }
}