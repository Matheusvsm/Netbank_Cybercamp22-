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
    internal class PixServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IPixRepository, PixRepository>();
            services.AddScoped<IPixRepositoryFactory, PixRepositoryFactory>();
            services.AddScoped<IPixService, PixService>();
            services.AddScoped<IPixServiceFactory, PixServiceFactory>();
            services.AddScoped<IPixRepository, PixRepository>();
            services.AddScoped<IPixRepositoryFactory, PixRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IPixRepository, PixRepository>();
            services.AddSingleton<IPixRepositoryFactory, PixRepositoryFactory>();
            services.AddSingleton<IPixService, PixService>();
            services.AddSingleton<IPixServiceFactory, PixServiceFactory>();
            services.AddSingleton<IPixRepository, PixRepository>();
            services.AddSingleton<IPixRepositoryFactory, PixRepositoryFactory>();
        }
    }
}