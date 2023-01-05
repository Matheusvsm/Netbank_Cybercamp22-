using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.Fitbank;
using Osb.Core.Platform.Integration.Service.Fitbank.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    public class LimitedAccountServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ILimitedAccountService, LimitedAccountService>();
            services.AddScoped<ILimitedAccountServiceFactory, LimitedAccountServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ILimitedAccountService, LimitedAccountService>();
            services.AddSingleton<ILimitedAccountServiceFactory, LimitedAccountServiceFactory>();
        }
    }
}