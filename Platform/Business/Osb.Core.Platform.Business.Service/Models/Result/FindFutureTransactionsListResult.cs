using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindFutureTransactionsListResult
    {
        public List<FutureTransaction> Transactions { get; set; }
    }
}