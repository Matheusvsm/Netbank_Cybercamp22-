using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class FutureTransactionsServiceFactory : Interfaces.IFutureTransactionsServiceFactory
    {
        private IServiceProvider _provider;

        public FutureTransactionsServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public IFutureTransactionsService Create() => _provider.GetService<IFutureTransactionsService>();
    }
}
