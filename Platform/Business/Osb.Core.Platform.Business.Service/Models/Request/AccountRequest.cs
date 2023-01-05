using System;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class AccountRequest
    {
        public long CompanyId { get; set; }
        public long CompanyAuthenticationId { get; set; }
        public string TaxId { get; set; }
        public string Name { get; set; }
        public long Type { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string AccountKey { get; set; }
    }
}