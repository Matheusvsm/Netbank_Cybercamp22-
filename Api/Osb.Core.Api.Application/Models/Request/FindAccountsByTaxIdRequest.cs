namespace Osb.Core.Api.Application.Models.Request
{
    public class FindAccountListByTaxIdRequest : BaseRequest
    {
        public string TaxId { get; set; }
    }
}