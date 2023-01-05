using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Service
{
    public class ProfileServiceFactory : Interfaces.IProfileServiceFactory
    {
        private IServiceProvider _provider;

        public ProfileServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IProfileService Create() => _provider.GetService<IProfileService>();
    }
}