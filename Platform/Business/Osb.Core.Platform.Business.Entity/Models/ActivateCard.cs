using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class ActivateCard : BaseEntity
    {
        public long ActivateCardId { get; set; }
        public long AccountId { get; set; }
        public long OperationId { get; set; }
        public string IdentifierCard { get; set; }
        public ActivateCardStatus Status { get; set; }

        public static ActivateCard Create(long accountId, long userId, long operationId, string identifierCard)
        {
            return new ActivateCard
            {
                AccountId = accountId,
                OperationId = operationId,
                IdentifierCard = identifierCard,
                Status = ActivateCardStatus.Created,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}