using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindAccountOperationLimitListResult
    {
        public IEnumerable<AccountLimit> Limits { get; set; }
    }
}