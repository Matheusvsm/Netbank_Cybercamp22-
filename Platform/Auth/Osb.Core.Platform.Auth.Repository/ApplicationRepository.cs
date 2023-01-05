using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IDbContext<Application> _context;

        public ApplicationRepository(IDbContext<Application> context)
        {
            _context = context;
        }

        public Application GetApplicationByKey(string key, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramKey"] = key
            };

            return _context.ExecuteWithSingleResult("GetApplicationByKey", parameters, transactionScope);
        }
    }
}