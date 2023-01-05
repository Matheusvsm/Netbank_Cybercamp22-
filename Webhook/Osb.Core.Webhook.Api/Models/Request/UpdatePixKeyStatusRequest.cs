namespace Osb.Core.Webhook.Api.Models.Request
{
    public class UpdatePixKeyStatusRequest : BaseRequest
    {
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string PixKey { get; set; }
    }
}