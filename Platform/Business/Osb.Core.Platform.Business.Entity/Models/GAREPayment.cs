using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class GAREPayment : BaseEntity
    {
        public long GAREPaymentId { get; set; }
        public long AccountId { get; set; }
        public long OperationId { get; set; }
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
        public string CodeRevenue { get; set; }
        public string StateRegistration { get; set; }
        public string ActiveDebit { get; set; }
        public string QuoteNumberNotification { get; set; }
        public long RateValueType { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public long ExternalIdentifier { get; set; }
        public GAREType? GAREType { get; set; }
        public GAREPaymentStatus Status { get; set; }
        public int Attempts { get; set; }

        public static GAREPayment Create(long accountId, long operationId, string taxId, string contributorTaxId, string referenceNumber, decimal principalValue, decimal fineValue, decimal interestValue, decimal totalValue, decimal rateValue, DateTime dueDate, DateTime paymentDate, string codeRevenue, string stateRegistration, string activeDebit, string quoteNumberNotification, long rateValueType, string description, GAREType? gareType, long userId)
        {
            return new GAREPayment()
            {
                AccountId = accountId,
                OperationId = operationId,
                TaxId = taxId,
                ContributorTaxId = contributorTaxId,
                ReferenceNumber = referenceNumber,
                PrincipalValue = principalValue,
                FineValue = fineValue,
                InterestValue = interestValue,
                TotalValue = totalValue,
                RateValue = rateValue,
                DueDate = dueDate,
                PaymentDate = paymentDate,
                CodeRevenue = codeRevenue,
                StateRegistration = stateRegistration,
                ActiveDebit = activeDebit,
                QuoteNumberNotification = quoteNumberNotification,
                RateValueType = rateValueType,
                Description = description,
                Identifier = DateTime.Now.Ticks.ToString(),
                Status = GAREPaymentStatus.Created,
                GAREType = gareType,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}