using Osb.Core.Platform.Business.Entity.Models;
using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
  public class FindAccountsResult
  {
    public IEnumerable<Account> Accounts { get; set; }
  }
}