using System;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindInfosPaymentCIPByBarcodeResponse
    {
        [JsonPropertyName("TaxNumberBeneficiary")]
        public string ReceiverTaxId { get; set; }

        [JsonPropertyName("BeneficiaryName")]
        public string ReceiverName { get; set; }

        [JsonPropertyName("TaxNumberDrawee")]
        public string PayerTaxId { get; set; }

        [JsonPropertyName("DraweeName")]
        public string PayerName { get; set; }

        [JsonPropertyName("Value")]
        public decimal PaymentValue { get; set; }

        [JsonPropertyName("PaymentDate")]
        public DateTime PaymentDate { get; set; }

        [JsonPropertyName("DueDate")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("DiscountValue")]
        public decimal DiscountValue { get; set; }

        [JsonPropertyName("FineValue")]
        public decimal FineValue { get; set; }

        [JsonPropertyName("Barcode")]
        public string Barcode { get; set; }
    }
}