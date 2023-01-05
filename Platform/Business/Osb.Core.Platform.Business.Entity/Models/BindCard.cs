using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class BindCard : BaseEntity
    {
        public long AccountId { get; set; }
        public long BindCardId { get; set; }
        public long CardOwnerId { get; set; }
        public long CardHolderId { get; set; }
        public long CardHolderContactId { get; set; }
        public long OperationId { get; set; }
        public string IdentifierCard { get; set; }
        public UsageType UsageType { get; set; }
        public BindCardStatus Status { get; set; }

        public static BindCard Create(long accountId, long operationId, long cardOwnerId, long cardHolderId, long cardHolderContactId, string identifierCard, UsageType usageType, long userId)
        {
            return new BindCard
            {
                AccountId = accountId,
                OperationId = operationId,
                CardOwnerId = cardOwnerId,
                CardHolderId = cardHolderId,
                CardHolderContactId = cardHolderContactId,
                IdentifierCard = identifierCard,
                Status = BindCardStatus.Created,
                UsageType = usageType,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}