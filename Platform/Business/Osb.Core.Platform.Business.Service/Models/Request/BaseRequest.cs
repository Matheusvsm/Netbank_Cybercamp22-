using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class BaseRequest
    {
        [JsonPropertyName("accountId")]
        public long AccountId { get; set; }

        [JsonPropertyName("userId")]
        public long UserId { get; set; }
    }
}