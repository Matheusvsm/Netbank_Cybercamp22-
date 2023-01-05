using System;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindExpectedBoletoPaymentDateResponse
    {
        [JsonPropertyName("ExpectedDatePayment")]
        public DateTime ExpectedBoletoPaymentDate { get; set; }
    }
}