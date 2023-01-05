using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class NewAccountPersonDocumentRepositoryFactory : Interfaces.INewAccountPersonDocumentRepositoryFactory
    {
        private IServiceProvider _provider;

        public NewAccountPersonDocumentRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public INewAccountPersonDocumentRepository Create() => _provider.GetService<INewAccountPersonDocumentRepository>();
    }
}