using System;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindInfosPaymentByBarcodeReponse
    {
        public string DigitableLine { get; set; }

        public string Barcode { get; set; }

        public DateTime? DueDate { get; set; }

        public string BankCode { get; set; }

        public string BankName { get; set; }

        public decimal Value { get; set; }

        public string ConcessionaireName { get; set; }

        public string ConcessionaireCode { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}