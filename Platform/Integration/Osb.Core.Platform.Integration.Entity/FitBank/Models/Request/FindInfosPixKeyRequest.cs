using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindInfosPixKeyRequest : BaseRequest
    {
        public new string Method { get => "GetInfosPixKey"; }
        public string PixKeyValue { get; set; }
        public string TaxId { get; set; }
    }
}