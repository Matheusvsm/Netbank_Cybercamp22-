using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class TopUpRepositoryFactory : Interfaces.ITopUpRepositoryFactory
    {
        private IServiceProvider _provider;

        public TopUpRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ITopUpRepository Create() => _provider.GetService<ITopUpRepository>();
    }
}