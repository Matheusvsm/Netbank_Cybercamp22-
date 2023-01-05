using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class CancelFuturePaymentRequest : BaseRequest
    {
        public long ExternalIdentifier { get; set; }
        public OperationType OperationType { get; set; }
    }
}