using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class MoneyTransferServiceFactory : IMoneyTransferServiceFactory
    {
        private IServiceProvider _provider;
        public MoneyTransferServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public IMoneyTransferService Create()
        {
            return _provider.GetService<IMoneyTransferService>();
        }
    }
}