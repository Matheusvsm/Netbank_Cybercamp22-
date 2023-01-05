using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class ResendPixKeyToken : BaseRequest
    {
        public string PixKey { get; set; }
        public string TaxId { get; set; }
        public PixKeyType? PixKeyType { get; set; }
    }
}