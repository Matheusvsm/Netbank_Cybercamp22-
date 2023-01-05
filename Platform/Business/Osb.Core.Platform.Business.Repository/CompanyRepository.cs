using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbContext<Company> _context;

        public CompanyRepository(IDbContext<Company> context)
        {
            this._context = context;
        }
        public Company GetCompanyById(long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = companyId
            };

            Company company = _context.ExecuteWithSingleResult("GetCompanyById", parameters);

            return company;
        }
    }
}