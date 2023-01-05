using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindFGTSPaymentDetailsResponse : CommonTributeDetailsResponse
    {
        // TO-DO: Refatorar entidade posteriormente após a entrega(11/02/2022) e cada atributo e sua obrigatóriedade ou não.
        [JsonPropertyName("ContributorTaxNumber")]
        public string TaxIdContributor { get; set; }
        [JsonPropertyName("TaxNumber")]
        public string TaxId { get; set; }
        public long ReferenceNumber { get; set; }
        public string Barcode { get; set; }
        public string FgtsIdentifier { get; set; }
        public decimal TotalValue { get; set; }
        public string ReturnMessage { get; set; }
        public string ReturnCode { get; set; }
        public string SenderNameBank { get; set; }
        public string SenderCodeBank { get; set; }
        public string SenderBranch { get; set; }
        public string SenderAccount { get; set; }
        public string SenderAccountDigit { get; set; }
        public string ProtocolId { get; set; }
        [JsonPropertyName("DocumentNumber")]
        public long ExternalIdentifier { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public string ReceiptUrl { get; set; }
        public long SocialConnectivityCode { get; set; }
        public int SocialConnectivityDigit { get; set; }
    }
}