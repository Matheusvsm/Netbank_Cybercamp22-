using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindExpectedBoletoPaymentDateResponse
    {
        [JsonPropertyName("ExpectedDatePayment")]
        public string ExpectedBoletoPaymentDate { get; set; }
    }
}