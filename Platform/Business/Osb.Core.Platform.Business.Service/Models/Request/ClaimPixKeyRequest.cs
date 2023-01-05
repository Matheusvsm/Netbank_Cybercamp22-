using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class ClaimPixKeyRequest : BaseRequest
    {
        public string PixKey { get; set; }
        public string TaxNumber { get; set; }
        public PixKeyType PixKeyType { get; set; }
        public SPBAccount SPBAccount { get; set; }
    }
}