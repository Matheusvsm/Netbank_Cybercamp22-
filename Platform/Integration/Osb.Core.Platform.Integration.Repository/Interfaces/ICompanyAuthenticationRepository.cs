using Osb.Core.Platform.Integration.Entity.Models;

namespace Osb.Core.Platform.Integration.Repository.Interfaces
{
    public interface ICompanyAuthenticationRepository
    {
        CompanyAuthentication GetCompanyAuthenticationByAccountId(long accountId);

        CompanyAuthentication GetCompanyAuthenticationByCompanyId(long companyId);
    }

}