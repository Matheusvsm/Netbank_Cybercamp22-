using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class CancelCard : BaseEntity
    {
        public long AccountId { get; set; }
        public long CancelCardId { get; set; }
        public string IdentifierCard { get; set; }
        public CancelCardStatus Status { get; set; }
        public long OperationId { get; set; }

        public static CancelCard Create(long accountId, long userId, string identifierCard, long operationId)
        {
            return new CancelCard
            {
                AccountId = accountId,
                CreationUserId = userId,
                UpdateUserId = userId,
                IdentifierCard = identifierCard,
                OperationId = operationId,
                Status = CancelCardStatus.Created
            };
        }
    }
}