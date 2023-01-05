using System;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class InternalTransferRequest : BaseRequest
    {
        public new string Method { get => "InternalTransfer"; }
        public string FromTaxNumber { get; set; }
        public string FromBank { get; set; }
        public string FromBankBranch { get; set; }
        public string FromBankAccount { get; set; }
        public string FromBankAccountDigit { get; set; }
        public string ToTaxNumber { get; set; }
        public string ToBank { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public decimal Value { get; set; }
        public DateTime TransferDate { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
    }
}