using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class ChangePinCardRequest : BaseRequest
    {
        public new string Method { get => "ChangePinCard"; }
        public string IdentifierCard { get; set; }
        public string CurrentPin { get; set; }
        public string Pin { get; set; }
        public string PinCheck { get; set; }
        public string Salt { get; set; }
    }
}