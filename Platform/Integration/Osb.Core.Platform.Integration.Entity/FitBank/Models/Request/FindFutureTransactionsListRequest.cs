using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindFutureTransactionsListRequest : BaseRequest
    {
        public new string Method { get => "GetFutureTransactions"; }
        public OperationType? OperationType { get; set; }
        public FutureTransactionType FutureTransactionType { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string TaxId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public long? Index { get; set; }
        public long? PageSize { get; set; }
    }
}