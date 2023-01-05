namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class ReadHashCodeResult
    {
        public long AccountId { get; set; }
        public string AccountTaxId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}