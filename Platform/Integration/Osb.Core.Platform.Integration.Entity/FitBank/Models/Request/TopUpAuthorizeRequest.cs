using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class TopUpAuthorizeRequest : BaseRequest
    {
        public new string Method { get => "AuthorizeTopUp"; }
        public long ExternalIdentifier { get; set; }
        public string OriginNSU { get; set; }
    }
}