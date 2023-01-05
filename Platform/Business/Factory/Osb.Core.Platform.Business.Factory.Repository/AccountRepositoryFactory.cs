using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class AccountRepositoryFactory : Interfaces.IAccountRepositoryFactory
    {
        private IServiceProvider _provider;

        public AccountRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAccountRepository Create() => _provider.GetService<IAccountRepository>();
    }
}