using System.Text.Json.Serialization;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class TopUpWebhookRequest : BaseRequest
    {
        public string ProductKey { get; set; }

        [JsonPropertyName("documentNumber")]
        public string ExternalIdenfifier { get; set; }
        public string Status { get; set; }
    }
}