namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class CardOwnerRequest
    {
        public string OwnerTaxId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
    }
}