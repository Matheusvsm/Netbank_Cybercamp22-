using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class GenerateTopUpRequest : BaseRequest
    {
        public new string Method { get => "GenerateTopUp"; }
        public TopUpType? ProductType { get; set; }
        public string BatchIdentifier { get; set; }
        public string ProductKey { get; set; }
        public decimal? ProductValue { get; set; }
        public string ContractIdentifier { get; set; }
        public string OriginNSU { get; set; }
        public string TaxNumber { get; set; }
        public List<string> Tags { get; set; }
        public string FromBank { get; set; }
        public string FromBankBranch { get; set; }
        public string FromBankAccount { get; set; }
        public string FromBankAccountDigit { get; set; }
        public int? PeriodicRepetition { get; set; }
        public DateTime TopUpDate { get; set; }
        public bool IsRecurrent { get; set; }
    }
}