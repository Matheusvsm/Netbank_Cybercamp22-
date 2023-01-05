using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class FavoredServiceFactory : Interfaces.IFavoredServiceFactory
    {
        private IServiceProvider _provider;

        public FavoredServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IFavoredService Create() => _provider.GetService<IFavoredService>();
    }
}