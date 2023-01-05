using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class BankingDataRepositoryFactory : Interfaces.IBankingDataRepositoryFactory
    {
        private IServiceProvider _provider;

        public BankingDataRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public IBankingDataRepository Create() => _provider.GetService<IBankingDataRepository>();
    }
}