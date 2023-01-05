using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class AccountServiceFactory : Interfaces.IAccountServiceFactory
    {
        private IServiceProvider _provider;

        public AccountServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAccountService Create() => _provider.GetService<IAccountService>();
    }
}