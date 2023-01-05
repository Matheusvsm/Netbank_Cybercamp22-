using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Osb.Core.Api.Application.Util;

namespace Osb.Core.Api.Application.Models.Request
{
    public class DARJPaymentRequest : BaseRequest
    {
        public string TaxId { get; set; }
        public string ContributorTaxId { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal PrincipalValue { get; set; }
        public decimal FineValue { get; set; }
        public decimal InterestValue { get; set; }
        public decimal MonetaryValue { get; set; }
        public decimal TotalValue { get; set; }
        public decimal RateValue { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DueDate { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime PaymentDate { get; set; }
        public List<string> Tags { get; set; }
        public string CodeRevenue { get; set; }
        public string StateRegistration { get; set; }
        public long OriginDocument { get; set; }
        public long RateValueType { get; set; }
        public string Description { get; set; }
    }
}