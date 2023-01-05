using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class BoletoPayment : BaseEntity
    {
        public long BoletoPaymentId { get; set; }
        public long AccountId { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverTaxId { get; set; }
        public string PayerName { get; set; }
        public string PayerTaxId { get; set; }
        public string Barcode { get; set; }
        public long OperationId { get; set; }
        public BoletoPaymentStatus Status { get; set; }
        public decimal PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal DiscountValue { get; set; }
        public string Description { get; set; }
        public int Attempts { get; set; }
        public string Identifier { get; set; }
        public long ExternalIdentifier { get; set; }
        public string ResponseMessage { get; set; }

        public static BoletoPayment Create(long userId, long accountId, long operationId, string name, string taxId, string receiverName, string receiverTaxId, string payerName, string payerTaxId, string barcode, decimal paymentValue, DateTime paymentDate, DateTime? dueDate, decimal discountValue, string description, string identifier)
        {
            return new BoletoPayment
            {
                AccountId = accountId,
                Name = name,
                TaxId = taxId,
                ReceiverName = receiverName,
                ReceiverTaxId = receiverTaxId,
                PayerName = payerName,
                PayerTaxId = payerTaxId,
                OperationId = operationId,
                Status = BoletoPaymentStatus.Created,
                Barcode = barcode,
                PaymentValue = paymentValue,
                PaymentDate = paymentDate,
                DueDate = dueDate,
                DiscountValue = discountValue,
                Description = description,
                Identifier = DateTime.Now.Ticks.ToString(),
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}