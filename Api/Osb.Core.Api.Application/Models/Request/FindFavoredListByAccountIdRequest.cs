using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindFavoredListByAccountIdRequest : BaseRequest
    {
        public OperationType OperationType { get; set; }
    }
}