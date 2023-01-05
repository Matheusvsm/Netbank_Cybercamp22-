using System;
using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class DARJPaymentRequest : BaseRequest
    {
        public new string Method { get => "GeneratePaymentDARJ"; }
        public long DARJPaymentId {get; set; }
        public string TaxId { get; set; }
        public string ContributorTaxId { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal PrincipalValue {get; set; }
        public decimal FineValue { get; set; }
        public decimal InterestValue { get; set; }
        public decimal MonetaryValue { get; set; }
        public decimal TotalValue { get; set; }
        public decimal RateValue { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<string> Tags { get; set; }
        public string CodeRevenue { get; set; }
        public string StateRegistration { get; set; }
        public long OriginDocument { get; set; }
        public long RateValueType { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public string FromBank { get; set; }
        public string FromBankBranch { get; set; }
        public string FromBankAccount { get; set; }
        public string FromBankAccountDigit { get; set; }
    }
}