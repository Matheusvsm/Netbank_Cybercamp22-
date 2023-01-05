using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IFavoredService
    {

        void Save(FavoredRequest insertFavoredRequest);

        FindFavoredListResult FindFavoredListByAccountIdAndOperationType(FindFavoredListByAccountIdRequest findFavoredRequest);
    }
}