using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindInfosPixKeyResponse : BaseResponse
    {
        public long SearchProtocol { get; set; }

        [JsonPropertyName("Infos")]
        public FindInfosPixKeyResponse FindInfosPixKeyResponse { get; set; }
    }
}