using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class OperationAttachmentRepositoryFactory : Interfaces.IOperationAttachmentRepositoryFactory
    {
        private IServiceProvider _provider;

        public OperationAttachmentRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IOperationAttachmentRepository Create() => _provider.GetService<IOperationAttachmentRepository>();
    }
}