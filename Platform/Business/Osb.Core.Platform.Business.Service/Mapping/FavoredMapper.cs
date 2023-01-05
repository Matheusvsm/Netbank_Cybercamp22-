using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Result;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class FavoredMapper
    {
        public FindFavoredListResult Map(IEnumerable<Favored> response)
        {
            return new FindFavoredListResult { FavoredList = response };
        }
    }
}