using System.Text.Json.Serialization;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class UpdatePixRequest : BaseRequest
    {
        [JsonPropertyName("DocumentNumber")]
        public long ExternalIdentifier { get; set; }
        public string Status { get; set; }
    }
}