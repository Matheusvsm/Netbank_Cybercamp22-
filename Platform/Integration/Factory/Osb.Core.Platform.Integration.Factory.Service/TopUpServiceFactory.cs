using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class TopUpServiceFactory : ITopUpServiceFactory
    {
        private IServiceProvider _provider;

        public TopUpServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ITopUpService Create()
        {
            return _provider.GetService<ITopUpService>();
        }
    }
}