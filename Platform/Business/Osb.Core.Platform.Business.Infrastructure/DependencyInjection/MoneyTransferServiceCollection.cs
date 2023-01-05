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
    internal class MoneyTransferServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IMoneyTransferService, MoneyTransferService>();
            services.AddScoped<IMoneyTransferServiceFactory, MoneyTransferServiceFactory>();
            services.AddScoped<IMoneyTransferRepository, MoneyTransferRepository>();
            services.AddScoped<IMoneyTransferRepositoryFactory, MoneyTransferRepositoryFactory>();
        }
        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IMoneyTransferServiceFactory, MoneyTransferServiceFactory>();
            services.AddSingleton<IMoneyTransferService, MoneyTransferService>();
            services.AddSingleton<IMoneyTransferRepository, MoneyTransferRepository>();
            services.AddSingleton<IMoneyTransferRepositoryFactory, MoneyTransferRepositoryFactory>();
        }
    }
}