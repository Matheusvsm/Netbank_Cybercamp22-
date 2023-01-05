using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class ResendPixKeyTokenRequest : BaseRequest
    {
        public string PixKey { get; set; }
        public string TaxId { get; set; }
        public PixKeyType? PixKeyType { get; set; }
    }
}