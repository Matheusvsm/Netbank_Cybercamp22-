namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindInfoPixQRCodeRequest : BaseRequest
    {
        public string Hash { get; set; }
        public string TaxId { get; set; }
    }
}