using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{

    public class FindInfoPixQRCodeRequest : BaseRequest
    {
        public new string Method { get => "GetInfosPixHashCode"; }
        public string TaxId { get; set; }
        public string Hash { get; set; }

    }
}