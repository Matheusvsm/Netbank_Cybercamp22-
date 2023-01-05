using System.Text.Json.Serialization;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class UpdateBoletoPaymentStatusRequest : BaseRequest
    {
        [JsonPropertyName("DocumentNumber")]
        public long ExternalIdentifier { get; set; }
        public string Status { get; set; }
    }
}