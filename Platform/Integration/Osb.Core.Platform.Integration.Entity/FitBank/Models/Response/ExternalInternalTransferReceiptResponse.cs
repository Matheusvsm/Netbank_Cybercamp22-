using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalInternalTransferReceiptResponse
    {
        [JsonPropertyName("InternalTransfer")]
        public string Transfer { get; set; }
    }
}