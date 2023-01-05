namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class CardOwnerRequest
    {
        public string OwnerTaxNumber { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
    }
}