using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindAccountOperationRequest : BaseRequest
    {
        public long OperationId { get; set; }
        public OperationType OperationType { get; set; }

    }
}