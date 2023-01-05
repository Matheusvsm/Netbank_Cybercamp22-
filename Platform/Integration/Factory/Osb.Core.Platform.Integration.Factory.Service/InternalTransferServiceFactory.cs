using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class InternalTransferServiceFactory : IInternalTransferServiceFactory
    {
        private IServiceProvider _provider;

        public InternalTransferServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IInternalTransferService Create()
        {
            return _provider.GetService<IInternalTransferService>();
        }
    }
}