namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindInfoPixQRCodeResult
    {
        public long SearchProtocol { get; set; }
        public string Hash { get; set; }
        public string ReceiverBank { get; set; }
        public string ReceiverBankBranch { get; set; }
        public string ReceiverBankAccount { get; set; }
        public string ReceiverBankAccountDigit { get; set; }
        public string ReceiverAccountType { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string PixKeyValue { get; set; }
        public string ExternalIdentifier { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverTaxNumber { get; set; }
        public string Description { get; set; }
        public string PayerName { get; set; }
        public string PayerTaxNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string OriginalValue { get; set; }
        public string ExpirationDate { get; set; }
        public string OriginalCreationDate { get; set; }
        public string Url { get; set; }
        public string Reusable { get; set; }
        public string UF { get; set; }
        public string RebateValue { get; set; }
        public string DiscountValue { get; set; }
        public string InterestValue { get; set; }
        public string FinalValue { get; set; }
        public string FineValue { get; set; }
        public string DueDate { get; set; }
        public string DaysAfterDueDate { get; set; }
        public string PaymentDate { get; set; }
        public string CategoryCode { get; set; }
        public string AdditionalData { get; set; }
        public string PayerRequest { get; set; }
        public string ExpirationQrCode { get; set; }
        public string ReceiverTradingName { get; set; }
        public string ReceiverPublicPlace { get; set; }
        public string IspbPss { get; set; }
        public string ChangeType { get; set; }
        public string WithdrawTransactionValue { get; set; }
        public string TransactionChangeType { get; set; }
        public string WithdrawIspbPss { get; set; }
        public string WithdrawAgentModality { get; set; }
        public string PurchaseWithChangeValue { get; set; }
        public string PurchaseWithChangeTransactionChangeType { get; set; }
        public string PurchaseWithChangeIspbPss { get; set; }
        public string PurchaseWithChangeAgentModality { get; set; }
    }
}