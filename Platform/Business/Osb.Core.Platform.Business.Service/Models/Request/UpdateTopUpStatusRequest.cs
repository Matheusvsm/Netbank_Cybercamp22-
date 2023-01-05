using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateTopUpStatusRequest : BaseRequest
    {
        public string ProductKey { get; set; }
        public long ExternalIdentifier { get; set; }
        public TopUpStatus TopUpStatus { get; set; }
    }
}