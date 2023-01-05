using System;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalBoletoPaymentResponse
    {

        [JsonPropertyName("Success")]
        public string Success { get; set; }
        
        public bool Status { get { return Convert.ToBoolean(Success); } set { Status = value; } }
    }
}