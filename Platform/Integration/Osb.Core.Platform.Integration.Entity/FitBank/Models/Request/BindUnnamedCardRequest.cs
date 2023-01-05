using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class BindUnnamedCardRequest : BaseRequest
    {
        public new string Method { get => "BindUnnamedCard"; }
        public CardOwnerRequest CardOwner { get; set; }
        public CardHolderRequest CardHolder { get; set; }
        public CardHolderContactRequest CardHolderContact { get; set; }
        public string IdentifierCard { get; set; }
        public string UsageType { get; set; }
    }
}