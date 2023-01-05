using System;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindCardResponse
    {
        [JsonPropertyName("CardHolderName")]
        public string CardHolderName { get; set; }

        [JsonPropertyName("CardHolderTaxNumber")]
        public string CardHolderTaxId { get; set; }

        [JsonPropertyName("CardOwnerName")]
        public string CardOwnerName { get; set; }

        [JsonPropertyName("CardOwnerTaxNumber")]
        public string CardOwnerTaxId { get; set; }

        [JsonPropertyName("IdentifierCard")]
        public string IdentifierCard { get; set; }

        [JsonPropertyName("Type")]
        public long Type { get; set; }

        [JsonPropertyName("Status")]
        public long Status { get; set; }

        [JsonPropertyName("PanLastDigits")]
        public string PanLastDigits { get; set; }

        [JsonPropertyName("ExpirationDate")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("UnlockedDate")]
        public string UnlockedDate { get; set; }

        [JsonPropertyName("LastBlockedDate")]
        public string LastBlockedDate { get; set; }

        [JsonPropertyName("IsBlocked")]
        public bool IsBlocked { get; set; }
        public string Success { get; set; }
        public bool ResponseStatus { get { return Convert.ToBoolean(Success); } set { ResponseStatus = value; } }
        public string Message { get; set; }
    }
}