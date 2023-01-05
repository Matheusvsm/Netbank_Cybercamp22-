using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class CompanyRepositoryFactory : Interfaces.ICompanyRepositoryFactory
    {
        private IServiceProvider _provider;

        public CompanyRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ICompanyRepository Create() => _provider.GetService<ICompanyRepository>();
    }
}