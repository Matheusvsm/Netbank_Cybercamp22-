using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Api.Factory.Repository.Interfaces;
using Osb.Core.Api.Repository;

namespace Osb.Core.Api.Factory.Repository
{
    public class ActionFunctionRepositoryFactory : IActionFunctionRepositoryFactory
    {
        private IServiceProvider _provider;

        public ActionFunctionRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IActionFunctionRepository Create() => _provider.GetService<IActionFunctionRepository>();

    }
}