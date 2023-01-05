using System;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindDARJPaymentDetailsResponse : CommonTributeDetailsResponse
    {
        // TO-DO: Refatorar entidade posteriormente após a entrega(11/02/2022) e cada atributo e sua obrigatóriedade ou não.
        public string CashOut { get; set; }
        public string CnabConfig { get; set; }
        [JsonPropertyName("TaxNumber")]
        public string TaxId { get; set; }
        public long OriginDocument { get; set; }
        public string NumberReference { get; set; }
        public decimal FineValue { get; set; }
        public decimal InterestValue { get; set; }
        public decimal MonetaryValue { get; set; }
        public decimal TotalValue { get; set; }
        public decimal RateValue { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public string ReceiptUrl { get; set; }
    }
}