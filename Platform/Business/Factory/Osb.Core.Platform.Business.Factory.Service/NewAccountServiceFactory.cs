using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class NewAccountServiceFactory : Interfaces.INewAccountServiceFactory
    {
        private IServiceProvider _provider;

        public NewAccountServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public INewAccountService Create() => _provider.GetService<INewAccountService>();
    }
}