namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindAccountListByTaxIdRequest : BaseRequest
    {
        public string TaxId { get; set; }
    }
}