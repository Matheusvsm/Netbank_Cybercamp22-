
namespace Osb.Core.Webhook.Api.Models.Request
{
    public class PixInRequest : BaseRequest
    {
        public string ToBankNumber { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public string ToTaxNumber { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; }
    }
}