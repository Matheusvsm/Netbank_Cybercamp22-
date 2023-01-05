using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Models;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class RefundPixIn : BaseEntity
    {
        public long RefundPixInId { get; set; }
        public long AccountId { get; set; }
        public long OperationId { get; set; }
        public string ToTaxId { get; set; }
        public string ToName { get; set; }
        public string ToBank { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public decimal RefundValue { get; set; }
        public string CustomerMessage { get; set; }
        public long DocumentNumber { get; set; }
        public string Identifier { get; set; }
        public int Attempts { get; set; }
        public RefundPixInStatus Status { get; set; }
        public long ExternalIdentifier { get; set; }

        public static RefundPixIn Create(long userId, long accountId, string toTaxId, string toName, string toBank, string toBankAccount, string toBankBranch, string toBankAccountDigit, decimal refundValue, string customerMessage, long documentNumber, long operationId)
        {
            return new RefundPixIn()
            {
                AccountId = accountId,
                ToTaxId = toTaxId,
                ToName = toName,
                ToBank = toBank,
                ToBankAccount = toBankAccount,
                ToBankBranch = toBankBranch,
                ToBankAccountDigit = toBankAccountDigit,
                RefundValue = refundValue,
                CustomerMessage = customerMessage,
                DocumentNumber = documentNumber,
                Identifier = DateTime.Now.Ticks.ToString(),
                OperationId = operationId,
                Status = RefundPixInStatus.Created,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}