using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class CommonTributeDetailsResponse
    {
        [JsonPropertyName("PrincipalValue")]
        public decimal Value { get; set; }
        public string NameContributor { get; set; }
        [JsonPropertyName("CodeRevenue")]
        public string RecipeCode { get; set; }
        [JsonPropertyName("PaymentDate")]
        public DateTime? Date { get; set; }
    }
}