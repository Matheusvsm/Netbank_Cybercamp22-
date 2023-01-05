using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class UpdateInternalTransferRequest : BaseRequest
    {
        public long? InternalTransferId { get; set; }
        public InternalTransferStatus Status { get; set; }
    }
}