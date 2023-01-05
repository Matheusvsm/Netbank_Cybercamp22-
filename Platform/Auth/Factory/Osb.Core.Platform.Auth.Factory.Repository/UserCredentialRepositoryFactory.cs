using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class UserCredentialRepositoryFactory : Interfaces.IUserCredentialRepositoryFactory
    {
        private IServiceProvider _provider;

        public UserCredentialRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public IUserCredentialRepository Create()
        {
            return _provider.GetService<IUserCredentialRepository>();
        }
    }
}