using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class InternalTransfer : BaseEntity
    {
        public long InternalTransferId { get; set; }
        public long OperationId { get; set; }
        public long FromAccountId { get; set; }
        public long ToAccountId { get; set; }
        public string Identifier { get; set; }
        public decimal TransferValue { get; set; }
        public DateTime TransferDate { get; set; }
        public InternalTransferStatus Status { get; set; }
        public long ExternalIdentifier { get; set; }
        public string Description { get; set; }
        public int Attempts { get; set; }
        public string ResponseMessage { get; set; }

        public static InternalTransfer Create(long fromAccountId, long toAccountId, decimal transferValue, DateTime transferDate, string description, long operationId, long userId)
        {
            return new InternalTransfer
            {
                FromAccountId = fromAccountId,
                Identifier = DateTime.Now.Ticks.ToString(),
                ToAccountId = toAccountId,
                TransferValue = transferValue,
                TransferDate = transferDate,
                Status = InternalTransferStatus.Created,
                Description = description,
                OperationId = operationId,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}
