using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class OperationTagServiceFactory : Interfaces.IOperationTagServiceFactory
    {
        private IServiceProvider _provider;

        public OperationTagServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        
        public IInternalTransferService Create() => _provider.GetService<IInternalTransferService>();
    }
}