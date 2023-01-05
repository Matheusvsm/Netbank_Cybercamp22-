using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.Fitbank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class NewAccountServiceFactory : INewAccountServiceFactory
    {
        private IServiceProvider _provider;

        public NewAccountServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public INewAccountService Create()
        {
            return _provider.GetService<INewAccountService>();
        }

    }
}