using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Webhook.Repository;

namespace Osb.Core.Webhook.Factory.Repository
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
