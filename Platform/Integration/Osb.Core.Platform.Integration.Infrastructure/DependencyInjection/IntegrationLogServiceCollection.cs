using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Repository;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Repository;
using Osb.Core.Platform.Integration.Repository.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    public class IntegrationLogServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IIntegrationLogRepository, IntegrationLogRepository>();
            services.AddScoped<IIntegrationLogRepositoryFactory, IntegrationLogRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IIntegrationLogRepository, IntegrationLogRepository>();
            services.AddSingleton<IIntegrationLogRepositoryFactory, IntegrationLogRepositoryFactory>();
        }
    }
}