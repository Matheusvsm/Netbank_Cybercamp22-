namespace Osb.Core.Api.Application.Models.Request
{
    public class UnblockCardRequest : BaseRequest
    {
        public string IdentifierCard { get; set; }
        public string Pin { get; set; }
    }
}