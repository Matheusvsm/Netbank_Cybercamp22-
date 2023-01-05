using System;
using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FGTSPaymentRequest : BaseRequest
    {
        public string TaxId { get; set; }
        public string ContributorTaxId { get; set; }
        public decimal PrincipalValue { get; set; }
        public string CodeRevenue { get; set; }
        public string Barcode {get; set;}
        public string FgtsIdentifier {get; set;}
        public long SocialConnectivityCode {get; set;}
        public int SocialConnectivityDigit {get; set;}
        public DateTime PaymentDate { get; set; }
        public List<string> Tags { get; set; }
        public long RateValueType { get; set; }
        public string Description { get; set; }
    }
}