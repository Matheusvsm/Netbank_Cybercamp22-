using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class AccountServiceFactory : IAccountServiceFactory
    {
        private IServiceProvider _provider;

        public AccountServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IAccountService Create()
        {
            return _provider.GetService<IAccountService>();
        }

    }
}