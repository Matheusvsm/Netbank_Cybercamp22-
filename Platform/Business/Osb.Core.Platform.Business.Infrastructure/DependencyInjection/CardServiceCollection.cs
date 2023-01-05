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
    public class CardServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardServiceFactory, CardServiceFactory>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardRepositoryFactory, CardRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ICardService, CardService>();
            services.AddSingleton<ICardServiceFactory, CardServiceFactory>();
            services.AddSingleton<ICardRepository, CardRepository>();
            services.AddSingleton<ICardRepositoryFactory, CardRepositoryFactory>();
        }
    }
}