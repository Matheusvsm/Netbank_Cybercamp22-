using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindAccountDashboardResult
    {
        public Account Account { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
        public decimal Balance { get; set; }
        public List<long> UIFunctions { get; set; }
    }
}