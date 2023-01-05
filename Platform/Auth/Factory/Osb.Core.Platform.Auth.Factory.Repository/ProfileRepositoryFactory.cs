using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class ProfileRepositoryFactory : Interfaces.IProfileRepositoryFactory
    {
        private IServiceProvider _provider;

        public ProfileRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public IProfileRepository Create()
        {
            return _provider.GetService<IProfileRepository>();
        }
    }
}