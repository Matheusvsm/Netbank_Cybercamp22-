using Microsoft.Extensions.DependencyInjection;
using System;
using Osb.Core.Platform.Auth.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Service
{
    public class AuthorizationTokenServiceFactory : Interfaces.IAuthorizationTokenServiceFactory
    {
       private IServiceProvider _provider;

        public AuthorizationTokenServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAuthorizationTokenService Create() => _provider.GetService<IAuthorizationTokenService>();
    }
}