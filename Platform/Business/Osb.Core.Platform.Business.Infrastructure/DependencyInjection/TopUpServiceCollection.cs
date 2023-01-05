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
    internal class TopUpServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ITopUpService, TopUpService>();
            services.AddScoped<ITopUpServiceFactory, TopUpServiceFactory>();
            services.AddScoped<ITopUpRepository, TopUpRepository>();
            services.AddScoped<ITopUpRepositoryFactory, TopUpRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ITopUpServiceFactory, TopUpServiceFactory>();
            services.AddSingleton<ITopUpService, TopUpService>();
            services.AddSingleton<ITopUpRepositoryFactory, TopUpRepositoryFactory>();
            services.AddSingleton<ITopUpRepository, TopUpRepository>();
        }
    }
}