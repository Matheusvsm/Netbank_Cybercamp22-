using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class MoneyTransferServiceFactory : Interfaces.IMoneyTransferServiceFactory
    {
        private IServiceProvider _provider;

        public MoneyTransferServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IMoneyTransferService Create() => _provider.GetService<IMoneyTransferService>();
    }
}