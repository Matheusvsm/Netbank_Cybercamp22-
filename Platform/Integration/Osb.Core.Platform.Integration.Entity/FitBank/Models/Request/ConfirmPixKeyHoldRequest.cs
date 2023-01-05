using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class ConfirmPixKeyHoldRequest : BaseRequest
    {
        public new string Method { get => "ConfirmPixKeyHold"; }
        public string PixKey { get; set; }
        public string TaxId { get; set; }
        public PixKeyType? PixKeyType { get; set; }
        public string ConfirmationCode { get; set; }
        
    }
}