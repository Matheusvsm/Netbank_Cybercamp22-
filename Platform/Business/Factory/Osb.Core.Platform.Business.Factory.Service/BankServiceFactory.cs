using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class BankServiceFactory : Interfaces.IBankServiceFactory
    {
        private IServiceProvider _provider;

        public BankServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IBankService Create() => _provider.GetService<IBankService>();
    }
}