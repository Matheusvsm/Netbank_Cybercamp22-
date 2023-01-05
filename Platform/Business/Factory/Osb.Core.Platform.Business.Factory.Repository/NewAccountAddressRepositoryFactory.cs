using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class NewAccountAddressRepositoryFactory : Interfaces.INewAccountAddressRepositoryFactory
    {
        private IServiceProvider _provider;

        public NewAccountAddressRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public INewAccountAddressRepository Create() => _provider.GetService<INewAccountAddressRepository>();
    }
}