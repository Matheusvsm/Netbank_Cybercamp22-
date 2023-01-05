using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateMoneyTransferRequest : BaseRequest
    {
        public long? MoneyTransferId { get; set; }
        public long? ExternalIdentifier { get; set; }
        public MoneyTransferStatus Status { get; set; }
    }
}