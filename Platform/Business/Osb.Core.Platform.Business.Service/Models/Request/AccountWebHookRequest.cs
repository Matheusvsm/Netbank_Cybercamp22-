namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class AccountWebhookRequest
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string AccountKey { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public SPBAccount SPBAccount { get; set; }
    }
}