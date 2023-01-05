using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindFavoredListByAccountIdRequest : BaseRequest
    {
        public OperationType OperationType { get; set; }
    }
}