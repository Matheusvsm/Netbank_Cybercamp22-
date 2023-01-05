using System;
using System.Text.Json.Serialization;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models
{
    public class FuturePayment
    {
        [JsonPropertyName("DocumentNumber")]
        public long Identifier { get; set; }

        [JsonPropertyName("DraweeName")]
        public string Name { get; set; }

        public PaymentType? PaymentType { get; set; }

        [JsonPropertyName("Status")]
        public PaymentStatus PaymentStatus { get; set; }

        public string TypeDescription { get; set; }

        public decimal Value { get; set; }

        public DateTime? PaymentDate { get; set; }

    }
}