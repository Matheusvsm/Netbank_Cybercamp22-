using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class BankingDataServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IBankingDataRepository, BankingDataRepository>();
            services.AddScoped<IBankingDataRepositoryFactory, BankingDataRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IBankingDataRepository, BankingDataRepository>();
            services.AddSingleton<IBankingDataRepositoryFactory, BankingDataRepositoryFactory>();
        }
    }
}