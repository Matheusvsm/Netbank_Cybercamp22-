using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class GAREPaymentRequest : BaseRequest
    {
        public string TaxId { get; set; }
        public string ContributorTaxId { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal PrincipalValue { get; set; }
        public decimal FineValue { get; set; }
        public decimal InterestValue { get; set; }
        public decimal TotalValue { get; set; }
        public decimal RateValue { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<string> Tags { get; set; }
        public string CodeRevenue { get; set; }
        public string StateRegistration { get; set; }
        public string ActiveDebit { get; set; }
        public string QuoteNumberNotification { get; set; }
        public long RateValueType { get; set; }
        public string Description { get; set; }
        public GAREType? GAREType { get; set; }
    }
}