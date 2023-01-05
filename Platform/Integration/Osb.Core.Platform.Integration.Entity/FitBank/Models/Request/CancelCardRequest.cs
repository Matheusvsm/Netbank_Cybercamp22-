using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class CancelCardRequest : BaseRequest
    {
        public new string Method { get => "CancelCard"; }
        public string IdentifierCard { get; set; }
    }
}