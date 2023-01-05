using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindAccountOperationLimitResponse : BaseResponse
    {
        [JsonPropertyName("MinLimit")]
        public decimal MinValue { get; set; }
        [JsonPropertyName("MaxLimit")]
        public decimal MaxValue { get; set; }
    }
}