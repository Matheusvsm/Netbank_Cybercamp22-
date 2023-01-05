using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Repository
{
    public class AccountLogRepository : IAccountLogRepository
    {
        private readonly IDbContext<AccountLog> _context;
        public AccountLogRepository(IDbContext<AccountLog> context)
        {
            this._context = context;
        }

        public void InsertAccountLog(string login)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login
            };

            _context.ExecuteWithNoResult("InsertAccountLog", parameters);
        }
    }
}