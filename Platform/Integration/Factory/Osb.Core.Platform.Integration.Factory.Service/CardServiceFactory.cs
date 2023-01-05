using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class CardServiceFactory : Interfaces.ICardServiceFactory
    {
        private IServiceProvider _provider;

        public CardServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public ICardService Create() => _provider.GetService<ICardService>();
    }
}
