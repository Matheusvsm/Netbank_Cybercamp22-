using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class CancelPixKeyRequest : BaseRequest
    {
        public string PixKeyValue { get; set; }
        public PixKeyType? PixKeyType { get; set; }
        public string TaxId { get; set; }
        public string SPBBank { get; set; }
        public string SPBBankBranch { get; set; }
        public string SPBBankAccount { get; set; }
        public string SPBBankAccountDigit { get; set; }
    }
}