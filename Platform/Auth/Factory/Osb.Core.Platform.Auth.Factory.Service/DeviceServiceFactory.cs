using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Service.Interfaces;


namespace Osb.Core.Platform.Auth.Factory.Service
{
    public class DeviceServiceFactory : Interfaces.IDeviceServiceFactory
    {
        private IServiceProvider _provider;

        public DeviceServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IDeviceService Create() => _provider.GetService<IDeviceService>();
    }
}