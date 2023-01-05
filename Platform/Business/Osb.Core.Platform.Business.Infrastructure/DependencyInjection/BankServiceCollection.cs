using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Service;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service;
using Osb.Core.Platform.Business.Service.Interfaces;
namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    public class BankServiceCollection
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