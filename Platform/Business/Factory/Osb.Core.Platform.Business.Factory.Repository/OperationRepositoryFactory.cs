using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
   public class OperationRepositoryFactory: Interfaces.IOperationRepositoryFactory
    {
        private IServiceProvider _provider;

        public OperationRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IOperationRepository Create() => _provider.GetService<IOperationRepository>();
    }
}