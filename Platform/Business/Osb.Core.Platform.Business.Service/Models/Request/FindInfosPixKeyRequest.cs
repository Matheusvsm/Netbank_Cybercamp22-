namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindInfosPixKeyRequest : BaseRequest
    {
        public string PixKeyValue { get; set; }
        public string TaxId { get; set; }
    }
}