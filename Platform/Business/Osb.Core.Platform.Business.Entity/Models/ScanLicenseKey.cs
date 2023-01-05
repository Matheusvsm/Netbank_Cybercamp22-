using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class ScanLicenseKey : BaseEntity
    {
        public long ScanLicenseKeyId { get; set; }
        public long CompanyId { get; set; }
        public string LicenseKey { get; set; }
    }
}