using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindTopUpProductListRequest : BaseRequest
    {
        public TopUpType? ProductType { get; set; }
        public TopUpProductSubType? ProductSubType { get; set; }
        public decimal? ProductValue { get; set; }
    }
}