using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class NewAccountPersonRepositoryFactory : Interfaces.INewAccountPersonRepositoryFactory
    {
        private IServiceProvider _provider;

        public NewAccountPersonRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public INewAccountPersonRepository Create() => _provider.GetService<INewAccountPersonRepository>();
    }
}