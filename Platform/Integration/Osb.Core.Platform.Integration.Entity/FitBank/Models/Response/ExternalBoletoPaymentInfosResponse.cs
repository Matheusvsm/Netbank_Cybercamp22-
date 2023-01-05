using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalBoletoPaymentInfosResponse : BaseResponse
    {
        [JsonPropertyName("Infos")]
        public string Data { get; set; }
    }
}