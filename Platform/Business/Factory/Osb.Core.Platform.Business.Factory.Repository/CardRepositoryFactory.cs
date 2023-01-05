using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository.Interfaces
{
    public class CardRepositoryFactory : Interfaces.ICardRepositoryFactory
    {
        private IServiceProvider _provider;

        public CardRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ICardRepository Create() => _provider.GetService<ICardRepository>();
    }
}