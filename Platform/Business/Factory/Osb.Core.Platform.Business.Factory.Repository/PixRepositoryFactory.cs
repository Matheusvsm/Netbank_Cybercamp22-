using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class PixRepositoryFactory : Interfaces.IPixRepositoryFactory 
    {
        private IServiceProvider _provider;

        public PixRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public IPixRepository Create() => _provider.GetService<IPixRepository>();

    }
}