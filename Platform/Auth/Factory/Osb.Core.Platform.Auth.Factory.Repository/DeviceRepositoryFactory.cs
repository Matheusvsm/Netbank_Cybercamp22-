using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class DeviceRepositoryFactory : Interfaces.IDeviceRepositoryFactory
    {
        private IServiceProvider _provider;

        public DeviceRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IDeviceRepository Create()
        {
            return _provider.GetService<IDeviceRepository>();
        }
    }
}