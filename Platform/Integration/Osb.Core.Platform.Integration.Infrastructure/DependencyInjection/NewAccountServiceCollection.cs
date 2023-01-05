using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.Fitbank;
using Osb.Core.Platform.Integration.Service.Fitbank.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    internal class NewAccountServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<INewAccountService, NewAccountService>();
            services.AddScoped<INewAccountServiceFactory, NewAccountServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<INewAccountService, NewAccountService>();
            services.AddSingleton<INewAccountServiceFactory, NewAccountServiceFactory>();
        }
    }
}