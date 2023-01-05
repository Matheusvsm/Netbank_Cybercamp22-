using System;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindPixDetailsResponse
    {
        [JsonPropertyName("DocumentNumber")]
        public long ExternalIdentifier { get; set; }
        public string Identifier { get; set; }
        [JsonPropertyName("FromName")]
        public string Name { get; set; }

        [JsonPropertyName("FromTaxNumber")]
        public string TaxId { get; set; }
        [JsonPropertyName("FromBankCode")]
        public string Bank { get; set; }
        [JsonPropertyName("FromBankBranch")]
        public string BankBranch { get; set; }
        [JsonPropertyName("FromBankAccount")]
        public string BankAccount { get; set; }
        [JsonPropertyName("FromBankAccountDigit")]
        public string BankAccountDigit { get; set; }
        public string ToName { get; set; }

        [JsonPropertyName("ToTaxNumber")]
        public string ToTaxId { get; set; }
        public string ToBankCode { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public decimal RateValue { get; set; }
        [JsonPropertyName("TotalValue")]
        public decimal Value { get; set; }
        public string ReceiptUrl { get; set; }
        [JsonPropertyName("PaymentDate")]
        public string Date { get; set; }
        public string Status { get; set; }
        public string Success { get; set; }
        public bool StatusResponse { get { return Convert.ToBoolean(Success); } set { StatusResponse = value; } }
        public string Message { get; set; }

    }
}