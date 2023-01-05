using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class ReadHashCodeRequest : BaseRequest
    {
        public new string Method { get => "ReadQRCode"; }
        public string HashCode { get; set; }
    }
}