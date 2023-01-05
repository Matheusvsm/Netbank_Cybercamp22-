using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class ActionFunctionRepositoryFactory : Interfaces.IActionFunctionRepositoryFactory
    {
        private IServiceProvider _provider;

        public ActionFunctionRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public IActionFunctionRepository Create()
        {
            return _provider.GetService<IActionFunctionRepository>();
        }
    }
}