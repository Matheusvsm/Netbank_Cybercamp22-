using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
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
