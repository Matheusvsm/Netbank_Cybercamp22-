using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class ExceptionLogRepositoryFactory : Interfaces.IExceptionLogRepositoryFactory
    {
        private IServiceProvider _provider;

        public ExceptionLogRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IExceptionLogRepository Create() => _provider.GetService<IExceptionLogRepository>();
    }
}