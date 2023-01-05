using System;
using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindBankStatementDetailsResult
    {
        public decimal? Value { get; set; }
        public string FromBank { get; set; }
        public string FromBankBranch { get; set; }
        public string FromBankAccount { get; set; }
        public string FromBankAccountDigit { get; set; }
        public string ToName { get; set; }
        public string ToTaxId { get; set; }
        public string ToBank { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string ReceiptUrl { get; set; }
    }
}