namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class ChangePinCardRequest : BaseRequest
    {
        public long ChangePinCardId { get; set; }
        public string IdentifierCard { get; set; }
        public string CurrentPin { get; set; }
        public string Pin { get; set; }
        public string ConfirmationPin { get; set; }
        public string Salt { get; set; }
        public int Attempts { get; set; }
        
    }
}