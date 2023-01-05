using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class LimitedAccountServiceFactory : Interfaces.ILimitedAccountServiceFactory
    {
        private IServiceProvider _provider;

        public LimitedAccountServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ILimitedAccountService Create() => _provider.GetService<ILimitedAccountService>();
    }
}