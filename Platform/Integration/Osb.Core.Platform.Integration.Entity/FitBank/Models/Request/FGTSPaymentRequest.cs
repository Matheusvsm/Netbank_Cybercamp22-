using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FGTSPaymentRequest : BaseRequest
    {
        public new string Method { get => "GeneratePaymentFGTS"; }
        public long FGTSPaymentId {get; set;}
        public string TaxId { get; set; }
        public string ContributorTaxId { get; set; }
        public string FromBank { get; set; }
        public string FromBankBranch { get; set; }
        public string FromBankAccount { get; set; }
        public string FromBankAccountDigit { get; set; }
        public decimal PrincipalValue { get; set; }
        public string CodeRevenue { get; set; }
        public string Barcode {get; set;}
        public string FgtsIdentifier {get; set;}
        public long SocialConnectivityCode {get; set;}
        public int SocialConnectivityDigit {get; set;}
        public DateTime PaymentDate { get; set; }
        public List<string> Tags { get; set; }
        public long RateValueType { get; set; }
        public string Description {get; set;}
        public string Identifier {get; set;}
    }
}