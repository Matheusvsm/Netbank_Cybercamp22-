using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class UserAccountRepositoryFactory : Interfaces.IUserAccountRepositoryFactory
    {
        private IServiceProvider _provider;

        public UserAccountRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IUserAccountRepository Create() => _provider.GetService<IUserAccountRepository>();
    }
}