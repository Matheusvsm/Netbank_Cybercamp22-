using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindInfosPixKeyRequest : BaseRequest
    {
        public string PixKeyValue { get; set; }
        public string TaxId { get; set; }
        public PixKeyType PixKeyType { get; set; }
    }
}