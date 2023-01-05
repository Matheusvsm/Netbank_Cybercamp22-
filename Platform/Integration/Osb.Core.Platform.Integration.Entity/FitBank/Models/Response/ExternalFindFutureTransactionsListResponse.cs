using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindFutureTransactionsListResponse
    {
        [JsonPropertyName("FutureTransactions")]
        public string Transactions { get; set; }
    }
}