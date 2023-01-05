namespace Osb.Core.Webhook.Api.Models.Request
{
    public class AccountWebhookRequest : BaseRequest
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string AccountKey { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public SPBAccount SPBAccount { get; set; }
    }
}