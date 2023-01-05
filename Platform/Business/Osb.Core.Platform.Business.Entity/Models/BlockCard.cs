using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class BlockCard : BaseEntity
    {
        public long BlockCardId { get; set; }
        public long AccountId { get; set; }
        public long OperationId { get; set; }
        public string IdentifierCard { get; set; }
        public string Pin { get; set; }
        public string Salt { get; set; }
        public CardReasonCode ReasonCode { get; set; }
        public BlockCardStatus Status { get; set; }

        public static BlockCard Create(long userId, long accountId, String identifierCard, string pin, long operation)
        {
            return new BlockCard
            {
                AccountId = accountId,
                IdentifierCard = identifierCard,
                Pin = pin,
                ReasonCode = CardReasonCode.ChangePin,
                Status = BlockCardStatus.Created,
                OperationId = operation,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}