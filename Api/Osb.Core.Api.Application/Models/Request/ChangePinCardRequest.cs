namespace Osb.Core.Api.Application.Models.Request
{
    public class ChangePinCardRequest : BaseRequest
    {
        public string IdentifierCard { get; set; }
        public string CurrentPin { get; set; }
        public string Pin { get; set; }
        public string ConfirmationPin { get; set; }
    }
}