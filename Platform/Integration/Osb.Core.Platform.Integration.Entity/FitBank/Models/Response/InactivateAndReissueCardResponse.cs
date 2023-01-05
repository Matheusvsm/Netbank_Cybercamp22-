using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class InactivateAndReissueCardResponse : BaseResponse
    {
        [JsonPropertyName("Card")]
        public string IdentifierCard { get; set; }
    }
}