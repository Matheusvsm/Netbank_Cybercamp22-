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
    internal class FavoredServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IFavoredService, FavoredService>();
            services.AddScoped<IFavoredServiceFactory, FavoredServiceFactory>();
            services.AddScoped<IFavoredRepository, FavoredRepository>();
            services.AddScoped<IFavoredRepositoryFactory, FavoredRepositoryFactory>();
        }
        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IFavoredService, FavoredService>();
            services.AddSingleton<IFavoredServiceFactory, FavoredServiceFactory>();
            services.AddSingleton<IFavoredRepository, FavoredRepository>();
            services.AddSingleton<IFavoredRepositoryFactory, FavoredRepositoryFactory>();
        }
    }
}