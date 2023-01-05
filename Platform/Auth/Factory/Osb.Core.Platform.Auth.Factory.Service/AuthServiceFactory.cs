using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Service
{
    public class AuthServiceFactory : Interfaces.IAuthServiceFactory
    {
        private IServiceProvider _provider;

        public AuthServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAuthService Create() => _provider.GetService<IAuthService>();
    }
}