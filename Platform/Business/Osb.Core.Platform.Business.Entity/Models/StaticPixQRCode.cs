using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class StaticPixQRCode: BaseEntity
    {
        public long StaticPixQRCodeId { get; set; }
        public long UserId { get; set; }
        public long AccountId { get; set; }
        public long ExternalIdentifier { get; set; }
        public string QRCode { get; set; }
        public string HashCode { get; set; }
    }
}