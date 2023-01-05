using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class InternalTransferRepositoryFactory : Interfaces.IInternalTransferRepositoryFactory
    {
        private IServiceProvider _provider;

        public InternalTransferRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IInternalTransferRepository Create() => _provider.GetService<IInternalTransferRepository>();
    }
}