using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindTopUpProductListRequest : BaseRequest
    {
        public new string Method { get => "GetTopUpProducts"; }
        public TopUpType? ProductType { get; set; }
        public TopUpProductSubType? ProductSubType { get; set; }
        public decimal? ProductValue { get; set; }
    }
}