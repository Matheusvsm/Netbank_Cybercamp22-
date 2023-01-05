using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IActionFunctionRepository
    {
        ActionFunction GetByUserIdAndAccountIdAndActionAndController(long userId, long accountId, string action, string controller);
        ActionFunction GetActionFunctionById(long actionFunctionId);
    }
}