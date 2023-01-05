using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;


namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    internal class BankServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IBankServiceFactory, BankServiceFactory>();
        }
        
        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IBankService, BankService>();
            services.AddSingleton<IBankServiceFactory, BankServiceFactory>();
        }
    }
}