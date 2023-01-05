using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindCardListResult
    {
        public IEnumerable<Card> Cards { get; set; }
    }
}