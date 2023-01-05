using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class MoneyTransferRepositoryFactory : Interfaces.IMoneyTransferRepositoryFactory
    {
        private IServiceProvider _provider;

        public MoneyTransferRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IMoneyTransferRepository Create() => _provider.GetService<IMoneyTransferRepository>();
    }
}