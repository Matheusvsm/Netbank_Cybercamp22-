using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class ConfirmPixKeyHoldRequest : BaseRequest
    {
        public string PixKeyValue { get; set; }
        public PixKeyType? PixKeyType { get; set; }
        public string TaxId { get; set; }
        public string ConfirmationCode { get; set; }
    }
}