using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Repository.Interfaces;

namespace Osb.Core.Platform.Integration.Repository
{
    public class CompanyAuthenticationRepository : ICompanyAuthenticationRepository
    {
        private readonly IDbContext<CompanyAuthentication> _context;

        public CompanyAuthenticationRepository(IDbContext<CompanyAuthentication> context)
        {
            _context = context;
        }

        public CompanyAuthentication GetCompanyAuthenticationByAccountId(long accountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId
            };

            CompanyAuthentication companyAuthentication = _context.ExecuteWithSingleResult("GetCompanyAuthenticationByAccountId", parameters);
            return companyAuthentication;
        }

        public CompanyAuthentication GetCompanyAuthenticationByCompanyId(long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = companyId
            };

            CompanyAuthentication companyAuthentication = _context.ExecuteWithSingleResult("GetCompanyAuthenticationByCompanyId", parameters);
            return companyAuthentication;
        }
    }
}
