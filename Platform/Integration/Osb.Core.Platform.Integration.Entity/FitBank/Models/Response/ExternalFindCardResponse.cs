using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
  public class ExternalFindCardResponse
  {
    [JsonPropertyName("Card")]
    public string Data { get; set; }

    [JsonPropertyName("Message")]
    public string Message { get; set; }
  }
}