using System;
using Osb.Core.Platform.Common.Entity.Models;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class PixOut : BaseEntity
    {
        public long PixOutId { get; set; }
        public long AccountId { get; set; }
        public long OperationId { get; set; }
        public string ToName { get; set; }
        public string ToTaxId { get; set; }
        public string ToBank { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public decimal Value { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Identifier { get; set; }
        public string CustomerMessage { get; set; }
        public string PixKey { get; set; }
        public PixKeyType? PixKeyType { get; set; }
        public AccountType AccountType { get; set; }
        public string Description { get; set; }
        public long? SearchProtocol { get; set; }
        public long ExternalIdentifier { get; set; }
        public PixOutStatus Status { get; set; }
        public int Attempts { get; set; }
        public string ResponseMessage { get; set; }

        public static PixOut Create(long accountId, long operationId, long userId, string toName, string toTaxId, string toBank, string toBankBranch,
                                    string toBankAccount, string toBankAccountDigit, decimal value, DateTime paymentDate, string customerMessage,
                                    string pixKey, PixKeyType? pixKeyType, string description, AccountType accountType, long? searchProtocol)
        {
            return new PixOut
            {
                AccountId = accountId,
                OperationId = operationId,
                ToName = toName,
                ToTaxId = toTaxId,
                ToBank = toBank,
                ToBankBranch = toBankBranch,
                ToBankAccount = toBankAccount,
                ToBankAccountDigit = toBankAccountDigit,
                Value = value,
                Status = PixOutStatus.Created,
                Identifier = DateTime.Now.Ticks.ToString(),
                PaymentDate = paymentDate,
                CustomerMessage = customerMessage,
                PixKey = pixKey,
                PixKeyType = pixKeyType,
                AccountType = accountType,
                Description = description,
                SearchProtocol = searchProtocol,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}