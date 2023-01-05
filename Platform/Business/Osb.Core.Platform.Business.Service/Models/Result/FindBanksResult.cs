using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindBanksResult
    {
        public IEnumerable<Bank> Banks { get; set; }
    }
}