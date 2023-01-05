using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class InternalTransferServiceFactory : Interfaces.IInternalTransferServiceFactory
    {
        private IServiceProvider _provider;

        public InternalTransferServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IInternalTransferService Create() => _provider.GetService<IInternalTransferService>();
    }
}