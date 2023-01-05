using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindCardRequest : BaseRequest
    {
        public new string Method { get => "GetCardByIdentifierCard"; }
        public string IdentifierCard { get; set; }
    }
}