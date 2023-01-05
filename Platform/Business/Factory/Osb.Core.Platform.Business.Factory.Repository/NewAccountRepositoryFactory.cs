using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class NewAccountRepositoryFactory : Interfaces.INewAccountRepositoryFactory
    {
        private IServiceProvider _provider;

        public NewAccountRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public INewAccountRepository Create() => _provider.GetService<INewAccountRepository>();
    }
}