using Microsoft.Extensions.DependencyInjection;
using System;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class AccountLogRepositoryFactory : Interfaces.IAccountLogRepositoryFactory
    {
        private IServiceProvider _provider;

        public AccountLogRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAccountLogRepository Create() => _provider.GetService<IAccountLogRepository>();
    }
}