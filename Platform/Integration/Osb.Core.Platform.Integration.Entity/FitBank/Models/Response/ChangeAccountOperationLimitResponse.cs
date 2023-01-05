using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ChangeAccountOperationLimitResponse : BaseResponse
    {
        public decimal PreviousMinLimit { get; set; }
        public decimal PreviousMaxLimit { get; set; }

        [JsonPropertyName("NewMinValue")]
        public decimal NewMinLimit { get; set; }

        [JsonPropertyName("NewMaxValue")]
        public decimal NewMaxLimit { get; set; }
    }
}