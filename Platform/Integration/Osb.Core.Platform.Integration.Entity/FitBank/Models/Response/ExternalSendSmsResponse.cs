using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.Response
{
    public class ExternalSendSmsResponse
    {
        [JsonPropertyName("SentMessage")]
        public string Sent { get; set; }
    }
}