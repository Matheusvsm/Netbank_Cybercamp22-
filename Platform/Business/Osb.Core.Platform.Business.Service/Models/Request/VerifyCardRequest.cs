namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class VerifyCardRequest : BaseRequest
    {
        public string IdentifierCard { get; set; }
        public string TaxId { get; set; }
        public string PanLastDigits { get; set; }
        public long CompanyId { get; set; }
    }
}