using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class UnblockCard : BaseEntity
    {
        public long UnblockCardId { get; set; }
        public long AccountId { get; set; }
        public string IdentifierCard { get; set; }
        public string Pin { get; set; }
        public string Salt { get; set; }
        public UnblockCardStatus Status { get; set; }
        public long OperationId { get; set; }

        public static UnblockCard Create(long userId, long accountId, String identifierCard, string pin, long operation)
        {
            return new UnblockCard
            {
                AccountId = accountId,
                IdentifierCard = identifierCard,
                Pin = pin,
                Status = UnblockCardStatus.Created,
                OperationId = operation,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}