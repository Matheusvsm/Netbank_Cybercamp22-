using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindFavoredListResult
    {
        public IEnumerable<Favored> FavoredList { get; set; }
    }
}