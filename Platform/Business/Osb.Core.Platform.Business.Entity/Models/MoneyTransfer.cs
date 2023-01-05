using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class MoneyTransfer : BaseEntity
    {
        public long MoneyTransferId { get; set; }
        public string Identifier { get; set; }
        public long OperationId { get; set; }
        public long FromAccountId { get; set; }
        public string ToTaxId { get; set; }
        public string ToName { get; set; }
        public long BankingDataId { get; set; }
        public decimal TransferValue { get; set; }
        public DateTime TransferDate { get; set; }
        public MoneyTransferStatus Status { get; set; }
        public string Description { get; set; }
        public long ExternalIdentifier { get; set; }
        public int Attempts { get; set; }
        public string ResponseMessage { get; set; }

        public static MoneyTransfer Create(long accountId, string toTaxId, string toName, long bankingDataId, decimal transferValue, long operationId, long userId, DateTime transferDate, MoneyTransferStatus status, string description)
        {
            return new MoneyTransfer
            {
                FromAccountId = accountId,
                Identifier = DateTime.Now.Ticks.ToString(),
                ToTaxId = toTaxId,
                ToName = toName,
                BankingDataId = bankingDataId,
                TransferValue = transferValue,
                TransferDate = transferDate,
                Status = status,
                Description = description,
                OperationId = operationId,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}