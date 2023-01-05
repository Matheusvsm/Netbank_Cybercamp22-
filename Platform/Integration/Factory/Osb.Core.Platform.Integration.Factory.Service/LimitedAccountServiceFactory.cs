using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.Fitbank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class LimitedAccountServiceFactory : ILimitedAccountServiceFactory
    {
        private IServiceProvider _provider;

        public LimitedAccountServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ILimitedAccountService Create()
        {
            return _provider.GetService<ILimitedAccountService>();
        }
    }
}