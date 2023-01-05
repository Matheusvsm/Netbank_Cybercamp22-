using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Service
{
    public class ExceptionLogServiceFactory : Interfaces.IExceptionLogServiceFactory
    {
        private IServiceProvider _provider;

        public ExceptionLogServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IExceptionLogService Create() => _provider.GetService<IExceptionLogService>();
    }
}