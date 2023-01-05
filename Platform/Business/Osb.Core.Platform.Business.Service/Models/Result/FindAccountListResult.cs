using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindAccountListResult
    {
        public IEnumerable<Account> AccountList { get; set; }
    }
}