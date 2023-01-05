using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class TopUpServiceFactory : Interfaces.ITopUpServiceFactory
    {
        private IServiceProvider _provider;

        public TopUpServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ITopUpService Create() => _provider.GetService<ITopUpService>();
    }
}