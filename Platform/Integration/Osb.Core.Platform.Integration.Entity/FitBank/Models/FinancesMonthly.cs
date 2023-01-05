using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models
{
    public class FinancesMonthly
    {
        [JsonPropertyName("CashInValue")]
        public decimal MoneyInputValue { get; set; }

        [JsonPropertyName("CashOutValue")]
        public decimal MoneyOutputValue { get; set; }
    }
}