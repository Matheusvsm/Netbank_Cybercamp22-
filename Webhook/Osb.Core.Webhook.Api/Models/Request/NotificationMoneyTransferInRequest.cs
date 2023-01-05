namespace Osb.Core.Webhook.Api.Models.Request
{
    public class NotificationMoneyTransferInRequest : BaseRequest 
    {
        public string TaxNumber { get; set; }
        public string BankCode { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string Status{ get; set; }
        public decimal TotalValue { get; set; }
    }
}