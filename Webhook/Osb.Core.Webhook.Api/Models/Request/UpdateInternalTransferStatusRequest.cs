using System.Text.Json.Serialization;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class UpdateInternalTransferStatusRequest : BaseRequest
    {
        [JsonPropertyName("InternalTransferDocumentNumber")]
        public long ExternalIdentifier { get; set; }
        public string Status { get; set; }
    }
}