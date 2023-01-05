using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class BindCardRequest : BaseRequest
    {
        public string IdentifierCard { get; set; }
        public UsageType UsageType { get; set; }
        public CardOwnerRequest cardOwner { get; set; }
        public CardHolderRequest cardHolder { get; set; }
        public CardHolderContactRequest cardHolderContact { get; set; }
    }
}