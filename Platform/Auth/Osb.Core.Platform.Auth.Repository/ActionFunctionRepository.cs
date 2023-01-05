using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Api.Repository
{
    public class ActionFunctionRepository : IActionFunctionRepository
    {
        private readonly IDbContext<ActionFunction> _context;

        public ActionFunctionRepository(IDbContext<ActionFunction> context)
        {
            _context = context;
        }

        public ActionFunction GetActionFunctionById(long actionFunctionId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramActionFunctionId"] = actionFunctionId
            };

            ActionFunction actionFunction = _context.ExecuteWithSingleResult("getactionfunctionbyid", parameters);

            return actionFunction;
        }

        public ActionFunction GetByUserIdAndAccountIdAndActionAndController(long userId, long accountId, string action, string controller)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId,
                ["paramAccountId"] = accountId,
                ["paramAction"] = action,
                ["paramController"] = controller
            };

            ActionFunction actionFunction = _context.ExecuteWithSingleResult("getactionfunctionbyparameters", parameters);

            return actionFunction;
        }
    }
}