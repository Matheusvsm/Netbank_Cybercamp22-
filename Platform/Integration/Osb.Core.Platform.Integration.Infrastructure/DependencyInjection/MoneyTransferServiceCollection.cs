using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    internal class MoneyTransferServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IMoneyTransferService, MoneyTransferService>();
            services.AddScoped<IMoneyTransferServiceFactory, MoneyTransferServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IMoneyTransferService, MoneyTransferService>();
            services.AddSingleton<IMoneyTransferServiceFactory, MoneyTransferServiceFactory>();
        }
    }
}