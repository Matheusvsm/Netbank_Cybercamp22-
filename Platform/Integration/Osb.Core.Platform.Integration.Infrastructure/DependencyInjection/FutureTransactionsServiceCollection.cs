using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    internal class FutureTransactionsServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IFutureTransactionsService, FutureTransactionsService>();
            services.AddScoped<IFutureTransactionsServiceFactory, FutureTransactionsServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IFutureTransactionsService, FutureTransactionsService>();
            services.AddSingleton<IFutureTransactionsServiceFactory, FutureTransactionsServiceFactory>();
        }
    }
}