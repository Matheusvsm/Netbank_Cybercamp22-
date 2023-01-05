using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class RefundPixInRequest : BaseRequest
    {
        public new string Method { get => "GenerateRefundPixIn"; }
        public string ToTaxId { get; set; }
        public string TaxId { get; set; }
        public string ToName { get; set; }
        public string ToBank { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public decimal RefundValue { get; set; }
        public string CustomerMessage { get; set; }
        public long? DocumentNumber { get; set; }
        public string Identifier { get; set; }
        public List<string> Tags { get; set; }
    }
}