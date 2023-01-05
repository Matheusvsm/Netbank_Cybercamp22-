using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using System;
using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{

    public class GeneratePixOutRequest : BaseRequest
    {
        public new string Method { get => "GeneratePixOut"; }
        public string TaxId { get; set; }
        public string Identifier { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string ToName { get; set; }
        public string ToTaxId { get; set; }
        public string ToBank { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public AccountType? AccountType { get; set; }
        public string PixKey { get; set; }
        public PixKeyType? PixKeyType { get; set; }
        public long? SearchProtocol { get; set; }
        public decimal Value { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<string> Tags { get; set; }
    }
}
