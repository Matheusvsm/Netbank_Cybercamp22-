using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindPixQRCodeRequest : BaseRequest
    {
        public new string Method { get => "GetPixQRCodeById"; }
        public string TaxId { get; set; }
        public long ExternalIdentifier { get; set; }
    }
}