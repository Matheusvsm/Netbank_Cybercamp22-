namespace Osb.Core.Api.Application.Models.Request
{
    public class CancelCardRequest : BaseRequest
    {
        public string IdentifierCard { get; set; }
    }
}