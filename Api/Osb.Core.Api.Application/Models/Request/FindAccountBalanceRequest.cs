namespace Osb.Core.Api.Application.Models.Request
{
    public class FindAccountBalanceRequest : BaseRequest
    {
        public string TaxId { get; set; }
    }
}