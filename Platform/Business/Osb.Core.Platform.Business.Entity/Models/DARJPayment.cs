using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class DARJPayment : BaseEntity
    {
        public long DARJPaymentId { get; set; }
        public long AccountId { get; set; }
        public long OperationId { get; set; }
        public string TaxId { get; set; }
        public string ContributorTaxId { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal PrincipalValue { get; set; }
        public decimal FineValue { get; set; } 
        public decimal InterestValue { get; set; }
        public decimal MonetaryValue { get; set; }
        public decimal TotalValue { get; set; } 
        public decimal RateValue { get; set; } 
        public DateTime DueDate { get; set; }
        public string CodeRevenue { get; set; }
        public string StateRegistration { get; set; }
        public long OriginDocument { get; set; }
        public DateTime PaymentDate { get; set; }
        public long RateValueType { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public DARJPaymentStatus Status { get; set; }
        public int Attempts { get; set; }
        public long ExternalIdentifier { get; set; }

        public static DARJPayment Create(long accountId, long userId, long operationId, string taxId, string contributorTaxId, string referenceNumber, decimal principalValue, decimal fineValue, decimal interestValue, decimal monetaryValue, decimal totalValue, decimal rateValue, DateTime dueDate, string codeRevenue, string stateRegistration, long originDocument, DateTime paymentDate, long rateValueType, string description)
        {
            return new DARJPayment
            {
                AccountId = accountId,
                OperationId = operationId,
                TaxId = taxId,
                ContributorTaxId = contributorTaxId,
                ReferenceNumber = referenceNumber,
                PrincipalValue = principalValue,
                FineValue = fineValue,
                InterestValue = interestValue,
                MonetaryValue = monetaryValue,
                TotalValue = totalValue,
                RateValue = rateValue,
                DueDate = dueDate,
                CodeRevenue = codeRevenue,
                StateRegistration = stateRegistration,
                OriginDocument = originDocument,
                PaymentDate = paymentDate,
                RateValueType = rateValueType,
                Description = description,
                Identifier = DateTime.Now.Ticks.ToString(),
                Status = DARJPaymentStatus.Created,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        } 
    }
}