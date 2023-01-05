using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindBankStatementResponse
    {
        [JsonPropertyName("Entry")]
        public string Transactions { get; set; }
    }
}