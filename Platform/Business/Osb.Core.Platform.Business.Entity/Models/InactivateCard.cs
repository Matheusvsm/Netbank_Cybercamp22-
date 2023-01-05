using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class InactivateCard : BaseEntity
    {
        public long InactivateCardId { get; set; }
        public long AccountId { get; set; }
        public long OperationId { get; set; }
        public string IdentifierCard { get; set; }
        public CardReasonCode ReasonCode { get; set; }
        public InactivateCardStatus Status { get; set; }
        public string Pin { get; set; }
        public string Salt { get; set; }

        public static InactivateCard Create(string identifierCard, long accountId, long operationId, string pin, CardReasonCode reasonCode, long userId)
        {
            return new InactivateCard
            {
                IdentifierCard = identifierCard,
                AccountId = accountId,
                OperationId = operationId,
                Pin = pin,
                ReasonCode = reasonCode,
                Status = InactivateCardStatus.Created,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}