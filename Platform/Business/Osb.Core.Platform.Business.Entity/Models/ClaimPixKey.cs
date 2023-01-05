using System;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class ClaimPixKey : BaseEntity
    {
        public long ClaimPixKeyId { get; set; }
        public long AccountId { get; set; }
        public string TaxNumber { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
    }
}