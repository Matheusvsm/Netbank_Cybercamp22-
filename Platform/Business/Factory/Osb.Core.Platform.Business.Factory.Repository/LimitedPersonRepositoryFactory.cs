using Microsoft.Extensions.DependencyInjection;
using System;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class LimitedPersonRepositoryFactory : Interfaces.ILimitedPersonRepositoryFactory
    {
        private IServiceProvider _provider;

        public LimitedPersonRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ILimitedPersonRepository Create() => _provider.GetService<ILimitedPersonRepository>();
    }
}