using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        Company GetCompanyById(long companyId);
    }
}