using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class GenerateTopUpResponse : BaseResponse
    {
        [JsonPropertyName("DocumentNumber")]
        public long ExternalIdentifier { get; set; }

        [JsonPropertyName("Url")]
        public string UrlReceipt { get; set; }

        [JsonPropertyName("OriginNSU")]
        public string OriginNSU { get; set; }
    }
}