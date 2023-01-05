using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class ChangePinCard : BaseEntity
    {
        public long ChangePinCardId { get; set; }
        public long AccountId { get; set; }
        public long OperationId { get; set; }
        public string IdentifierCard { get; set; }
        public string CurrentPin { get; set; }
        public string Pin { get; set; }
        public string ConfirmationPin { get; set; }
        public ChangePinCardStatus Status { get; set; }
        public string Salt { get; set; }

        public static ChangePinCard Create(string identifierCard, long userId, long operationId, long accountId, string currentPin, string pin, string confirmationPin)
        {
            return new ChangePinCard
            {
                IdentifierCard = identifierCard,
                AccountId = accountId,
                OperationId = operationId,
                CurrentPin = currentPin,
                Pin = pin,
                ConfirmationPin = confirmationPin,
                Status = ChangePinCardStatus.Created,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}