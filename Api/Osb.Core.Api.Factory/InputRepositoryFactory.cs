using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Api.Repository;

namespace Osb.Core.Api.Factory.Repository
{
    public class InputRepositoryFactory : Interfaces.IInputRepositoryFactory
    {
        private IServiceProvider _provider;

        public InputRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IInputRepository Create() => _provider.GetService<IInputRepository>();
    }
}
