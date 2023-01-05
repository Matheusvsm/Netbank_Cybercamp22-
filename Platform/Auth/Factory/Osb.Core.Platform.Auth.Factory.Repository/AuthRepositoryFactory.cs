using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class AuthRepositoryFactory : IAuthRepositoryFactory
    {
        private IServiceProvider _provider;

        public AuthRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAuthRepository Create() 
        {
            return _provider.GetService<IAuthRepository>();
        }
    }
}