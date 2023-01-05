using System;
using System.Text.Json.Serialization;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models
{
    public class AccountLimit
    {
        
        public long AccountOperationLimitId { get; set; }

        public long AccountId { get; set; }

        public string AccountHolder { get; set; }

        public string AccountHolderTaxNumber { get; set; }

        public OperationType? OperationType { get; set; }

        public AccountOperationLimitType? Type { get; set; }

        public AccountOperationLimitSubType? SubType { get; set; }

        public decimal MinValue { get; set; }

        public decimal MaxValue { get; set; }

        public long BusinessUnitId { get; set; }
    }
}