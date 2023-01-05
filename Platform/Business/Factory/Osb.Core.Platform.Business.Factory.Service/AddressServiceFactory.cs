using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class AddressServiceFactory : Interfaces.IAddressServiceFactory
    {
        private IServiceProvider _provider;

        public AddressServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAddressService Create() => _provider.GetService<IAddressService>();
    }
}