using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateInternalTransferRequest : BaseRequest
    {
        public long? InternalTransferId { get; set; }
        public long? ExternalIdentifier { get; set; }
        public InternalTransferStatus Status { get; set; }
    }
}