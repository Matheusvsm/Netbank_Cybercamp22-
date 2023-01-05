using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class InactivateAndReissueCardRequest : BaseRequest
    {
        public new string Method { get => "InactivateAndReissueCard"; }
        public string IdentifierCard { get; set; }
        public string Pin { get; set; }
        public string ReasonCode { get; set; }
        public CardDeliveryAddressRequest CardDeliveryAddress { get; set; }
    }
}