using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class UserRepositoryFactory : Interfaces.IUserRepositoryFactory
    {
        private IServiceProvider _provider;

        public UserRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public IUserRepository Create()
        {
           return _provider.GetService<IUserRepository>();
        }
    }
}