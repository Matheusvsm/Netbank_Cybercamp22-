using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Repository
{
    public class UIFunctionRepository : IUIFunctionRepository
    {
        private readonly IDbContext<UIFunction> _context;

        public UIFunctionRepository(IDbContext<UIFunction> context)
        {
            this._context = context;
        }

        public IEnumerable<UIFunction> GetListByAccountIdAndUserId(long accountId, long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId,
                ["paramUserId"] = userId
            };

            IEnumerable<UIFunction> uIFunctionList = _context.ExecuteWithMultipleResults("GetUIfunctionListByAccountIdAndUserId", parameters);
            return uIFunctionList;
        }
    }
}