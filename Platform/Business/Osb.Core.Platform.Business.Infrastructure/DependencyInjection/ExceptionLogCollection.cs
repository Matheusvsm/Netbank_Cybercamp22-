using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Service;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class ExceptionLogCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IExceptionLogService, ExceptionLogService>();
            services.AddScoped<IExceptionLogServiceFactory, ExceptionLogServiceFactory>();
            services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();
            services.AddScoped<IExceptionLogRepositoryFactory, ExceptionLogRepositoryFactory>();
        }
        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IExceptionLogService, ExceptionLogService>();
            services.AddSingleton<IExceptionLogServiceFactory, ExceptionLogServiceFactory>();
            services.AddSingleton<IExceptionLogRepository, ExceptionLogRepository>();
            services.AddSingleton<IExceptionLogRepositoryFactory, ExceptionLogRepositoryFactory>();
        }
    }
}