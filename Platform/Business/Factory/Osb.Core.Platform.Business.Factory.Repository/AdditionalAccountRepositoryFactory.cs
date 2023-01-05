using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class AdditionalAccountRepositoryFactory : Interfaces.IAdditionalAccountRepositoryFactory
    {
        private IServiceProvider _provider;

        public AdditionalAccountRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAdditionalAccountRepository Create() => _provider.GetService<IAdditionalAccountRepository>();
    }
}