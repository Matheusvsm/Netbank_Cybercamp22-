using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class OperationTagRepositoryFactory : Interfaces.IOperationTagRepositoryFactory 
    {
        private IServiceProvider _provider;

        public OperationTagRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IOperationTagRepository Create() => _provider.GetService<IOperationTagRepository>();
    }
}