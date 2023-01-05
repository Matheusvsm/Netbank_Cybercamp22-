using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class CardServiceFactory : ICardServiceFactory
    {
        private IServiceProvider _provider;

        public CardServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public ICardService Create() => _provider.GetService<ICardService>();

    }
}