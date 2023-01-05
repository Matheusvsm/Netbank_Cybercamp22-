using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Service
{
    public class UserServiceFactory : Interfaces.IUserServiceFactory
    {
        private IServiceProvider _provider;

        public UserServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IUserService Create() => _provider.GetService<IUserService>();
    }
}