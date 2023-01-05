using System;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Osb.Core.Platform.Integration.Factory.Repository
{
    public class IntegrationLogRepositoryFactory : IIntegrationLogRepositoryFactory
    {
        private IServiceProvider _provider;

        public IntegrationLogRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public IIntegrationLogRepository Create() => _provider.GetService<IIntegrationLogRepository>();
    }
}