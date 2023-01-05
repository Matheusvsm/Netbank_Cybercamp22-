using Microsoft.Extensions.DependencyInjection;
using System;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class LimitedAccountRepositoryFactory : Interfaces.ILimitedAccountRepositoryFactory
    {
        private IServiceProvider _provider;

        public LimitedAccountRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ILimitedAccountRepository Create() => _provider.GetService<ILimitedAccountRepository>();
    }
}