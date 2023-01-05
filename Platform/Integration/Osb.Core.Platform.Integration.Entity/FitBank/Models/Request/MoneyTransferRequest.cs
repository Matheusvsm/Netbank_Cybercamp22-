using System;
using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class MoneyTransferRequest : BaseRequest
    {
        public new string Method { get => "MoneyTransfer"; }
        public string Identifier { get; set; }
        public string FromTaxId { get; set; }
        public string ToTaxId { get; set; }
        public string ToName { get; set; }
        public string Bank { get; set; }
        public int AccountType { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public decimal Value { get; set; }
        public DateTime TransferDate { get; set; }
        public string Description { get; set; }
        public string ExternalIdentification { get; set; }
        public List<string> Tags { get; set; }
    }
}