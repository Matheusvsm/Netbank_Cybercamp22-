using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class PixQRCode : BaseEntity
    {
        public string QRCode { get; set; }
        public string HashCode { get; set; }

    }
}