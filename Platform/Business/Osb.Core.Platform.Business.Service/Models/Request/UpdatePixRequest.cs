using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdatePixRequest : BaseRequest
    {
        public long? PixOutId { get; set; }
        public long? ExternalIdentifier { get; set; }
        public PixOutStatus Status { get; set; }
    }
}