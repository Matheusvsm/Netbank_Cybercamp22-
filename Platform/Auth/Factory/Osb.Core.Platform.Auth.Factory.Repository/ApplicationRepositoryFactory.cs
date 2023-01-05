using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class ApplicationRepositoryFactory : IApplicationRepositoryFactory
    {
        private IServiceProvider _provider;

        public ApplicationRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IApplicationRepository Create() => _provider.GetService<IApplicationRepository>();
    }
}