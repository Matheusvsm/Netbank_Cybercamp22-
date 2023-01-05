using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class PendingInternalTransfer : BaseEntity
    {
        public long PendingInternalTransferId { get; set; }
        public long AccountId { get; set; }
        public long OperationId { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public decimal Value { get; set; }
        public string Identifier { get; set; }
        public string FromTaxId { get; set; }
        public string FromBank { get; set; }
        public string FromBankBranch { get; set; }
        public string FromBankAccount { get; set; }
        public string FromBankAccountDigit { get; set; }
        public PendingInternalTransferStatus Status { get; set; }
        public int Attempts { get; set; }
        public long ExternalIdentifier { get; set; }

        public static PendingInternalTransfer Create(long accountId, long operationId, string phoneNumber, string countryCode, decimal value, string fromTaxId, string fromBank,
        string fromBankBranch, string fromBankAccount, string fromBankAccountDigit, long userId)
        {
            return new PendingInternalTransfer
            {
                AccountId = accountId,
                OperationId = operationId,
                PhoneNumber = phoneNumber,
                CountryCode = countryCode,
                Value = value,
                Identifier = DateTime.Now.Ticks.ToString(),
                FromTaxId = fromTaxId,
                FromBank = fromBank,
                FromBankBranch = fromBankBranch,
                FromBankAccount = fromBankAccount,
                FromBankAccountDigit = fromBankAccountDigit,
                Status = PendingInternalTransferStatus.Created,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}