using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class AuthorizationTokenRepositoryFactory : Interfaces.IAuthorizationTokenRepositoryFactory
    {   
        private IServiceProvider _provider;

        public AuthorizationTokenRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAuthorizationTokenRepository Create() 
        {
            return _provider.GetService<IAuthorizationTokenRepository>();
        }
    }}

