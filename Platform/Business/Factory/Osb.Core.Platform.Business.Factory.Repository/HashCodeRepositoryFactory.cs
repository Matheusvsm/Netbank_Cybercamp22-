using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class HashCodeRepositoryFactory : Interfaces.IHashCodeRepositoryFactory
    {
        private IServiceProvider _provider;

        public HashCodeRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IHashCodeRepository Create() => _provider.GetService<IHashCodeRepository>();

    }
} 