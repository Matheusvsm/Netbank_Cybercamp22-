namespace Osb.Core.Api.Application.Models.Request
{
    public class ValidateAuthorizationTokenRequest : BaseRequest
    {
        public string Code { get; set; }
        public string TaxId { get; set; }
    }
}