using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class UnblockCardRequest : BaseRequest
    {
        public new string Method {get => "UnblockCard"; }
        public string IdentifierCard { get; set; }
        public string Pin { get; set; }
    }
}