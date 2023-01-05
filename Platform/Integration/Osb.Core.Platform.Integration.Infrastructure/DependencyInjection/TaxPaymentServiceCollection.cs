using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    internal class TaxPaymentServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ITaxPaymentService, TaxPaymentService>();
            services.AddScoped<ITaxPaymentServiceFactory, TaxPaymentServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ITaxPaymentService, TaxPaymentService>();
            services.AddSingleton<ITaxPaymentServiceFactory, TaxPaymentServiceFactory>();
        }
    }
}