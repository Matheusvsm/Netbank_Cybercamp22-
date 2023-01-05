using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class NotificationMoneyTransferInRequest : BaseRequest
    {
        public string TaxId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public MoneyTransferStatus Status { get; set; }
        public decimal TransferValue { get; set; }
    }
}