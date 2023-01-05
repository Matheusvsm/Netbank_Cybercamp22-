using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindTransactionReceiptRequest : BaseRequest
    {
        public string ExternalIdentifier { get; set; }
        public OperationType OperationType { get; set; }
    }
}