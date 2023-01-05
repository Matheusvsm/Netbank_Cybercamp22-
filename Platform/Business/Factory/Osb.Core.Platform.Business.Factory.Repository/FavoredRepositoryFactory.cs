using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class FavoredRepositoryFactory : Interfaces.IFavoredRepositoryFactory
    {
        private IServiceProvider _provider;

        public FavoredRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IFavoredRepository Create() => _provider.GetService<IFavoredRepository>();
    }
}