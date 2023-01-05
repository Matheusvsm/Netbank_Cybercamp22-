using Microsoft.Extensions.DependencyInjection;
using System;
using Osb.Core.Platform.Integration.Repository.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Repository
{
    public class CompanyAuthenticationRepositoryFactory : Interfaces.ICompanyAuthenticationRepositoryFactory
    {
        private IServiceProvider _provider;

        public CompanyAuthenticationRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ICompanyAuthenticationRepository Create() => _provider.GetService<ICompanyAuthenticationRepository>();
    }
}