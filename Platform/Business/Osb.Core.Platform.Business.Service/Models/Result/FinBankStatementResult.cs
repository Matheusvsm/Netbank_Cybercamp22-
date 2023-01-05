using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindBankStatementResult
    {
        public List<DayTransactions> Transactions { get; set; }
    }
}