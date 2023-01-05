using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Service
{
    public class ActionFunctionServiceFactory : Interfaces.IActionFunctionServiceFactory
    {
        private IServiceProvider _provider;

        public ActionFunctionServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IActionFunctionService Create() => _provider.GetService<IActionFunctionService>();
    }
}