using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindBoletoInfoRequest : BaseRequest
    {
        public string TaxId { get; set; }
        public string NumericSequence { get; set; }
        public BoletoType BoletoType { get; set; }
    }
}