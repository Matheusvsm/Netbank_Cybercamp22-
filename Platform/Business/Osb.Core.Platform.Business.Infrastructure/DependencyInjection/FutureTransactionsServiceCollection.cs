using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Service;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    public class FutureTransactionsServiceCollection
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