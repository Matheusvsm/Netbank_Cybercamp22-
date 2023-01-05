using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindFuturePaymentsListResponse
    {
        [JsonPropertyName("ItemsToPay")]
        public string Payments { get; set; }
    }
}