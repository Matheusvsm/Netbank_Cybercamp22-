using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindCardListRequest : BaseRequest
    {
        public new string Method { get => "GetCardList"; }
        public string TaxId { get; set; }
    }
}