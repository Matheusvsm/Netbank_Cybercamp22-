using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    public class TopUpServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ITopUpService, TopUpService>();
            services.AddScoped<ITopUpServiceFactory, TopUpServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ITopUpService, TopUpService>();
            services.AddSingleton<ITopUpServiceFactory, TopUpServiceFactory>();
        }
    }
}