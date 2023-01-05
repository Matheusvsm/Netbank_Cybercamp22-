using System;
using System.Text.Json.Serialization;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models
{
    public class FutureTransaction
    {
        [JsonPropertyName("DocumentNumber")]
        public long Identifier { get; set; }
        public string Name { get; set; }
        public OperationType? OperationType { get; set; }
        public FutureTransactionStatus Status { get; set; }
        public string TypeDescription { get; set; }
        public decimal PrincipalValue { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}