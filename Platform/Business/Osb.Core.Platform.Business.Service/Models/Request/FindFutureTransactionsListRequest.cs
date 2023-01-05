using System;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindFutureTransactionsListRequest : BaseRequest
    {
        public OperationType? OperationType { get; set; }
        public FutureTransactionType FutureTransactionType { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public long? Index { get; set; }
        public long? PageSize { get; set; }
    }
}