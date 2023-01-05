using Osb.Core.Api.Entity;

namespace Osb.Core.Api.Repository
{
    public interface IActionFunctionRepository
    {
        ActionFunction GetByUserIdAndAccountIdAndActionAndController(long userId, long accountId, string action, string controller);
    }
}