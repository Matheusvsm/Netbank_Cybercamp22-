using System.Text.Json.Serialization;
namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindCardListResponse
    {
        [JsonPropertyName("Infos")]
        public string Cards { get; set; } 
    }
}