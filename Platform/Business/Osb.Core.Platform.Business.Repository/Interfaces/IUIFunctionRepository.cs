using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IUIFunctionRepository
    {
        IEnumerable<UIFunction> GetListByAccountIdAndUserId(long accountiId, long userId);
    }
}