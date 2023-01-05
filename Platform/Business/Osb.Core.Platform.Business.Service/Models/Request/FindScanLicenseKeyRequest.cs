using System;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindScanLicenseKeyRequest : BaseRequest
    {
        public long CompanyId { get; set; }
    }
}