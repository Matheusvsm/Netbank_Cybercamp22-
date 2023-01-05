using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Factory.Repository;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection
{
    internal class ApplicationServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationRepositoryFactory, ApplicationRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IApplicationRepository, ApplicationRepository>();
            services.AddSingleton<IApplicationRepositoryFactory, ApplicationRepositoryFactory>();
        }

        public static void AddTransientFactories(IServiceCollection services)
        {
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<IApplicationRepositoryFactory, ApplicationRepositoryFactory>();
        }
    }
}