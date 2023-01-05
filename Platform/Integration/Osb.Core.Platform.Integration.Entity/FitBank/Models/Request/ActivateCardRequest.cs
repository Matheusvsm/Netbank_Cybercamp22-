using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class ActivateCardRequest : BaseRequest
    {
        public new string Method { get => "ActivateCard"; }

        public string IdentifierCard { get; set; }
    }
}