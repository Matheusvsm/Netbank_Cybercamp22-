using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Entity.Response
{
    public class GenerateHashCodeResponse : BaseResponse
    {
        public string HashCode { get; set; }
        public string QRCodeBase64 { get; set; }
    }
}