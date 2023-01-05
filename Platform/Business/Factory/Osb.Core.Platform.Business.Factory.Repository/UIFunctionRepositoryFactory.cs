using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class UIFunctionRepositoryFactory : Interfaces.IUIFunctionRepositoryFactory
    {
        private IServiceProvider _provider;

        public UIFunctionRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IUIFunctionRepository Create() => _provider.GetService<IUIFunctionRepository>();
    }
}