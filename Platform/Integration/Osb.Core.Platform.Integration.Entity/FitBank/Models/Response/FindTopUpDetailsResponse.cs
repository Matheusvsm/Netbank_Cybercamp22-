using System;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindTopUpDetailsResponse
    {
        [JsonPropertyName("ProductValue")]
        public decimal Value { get; set; }
        [JsonPropertyName("PaymentDate")]
        public DateTime? Date { get; set; }
        [JsonPropertyName("DocumentNumber")]
        public long ExternalIdentifier { get; set; }
        public string Status { get; set; }
    }
}