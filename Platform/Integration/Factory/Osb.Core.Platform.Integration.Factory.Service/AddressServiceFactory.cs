using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class AddressServiceFactory :  Interfaces.IAddressServiceFactory
    {
        private IServiceProvider _provider;

        public AddressServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAddressService Create()
        {
            return _provider.GetService<IAddressService>();
        }
    }
}