namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindPixQrCodeRequest : BaseRequest
    {
        public long ExternalIdentifier { get; set; }
        public string TaxId { get; set; }
    }
}