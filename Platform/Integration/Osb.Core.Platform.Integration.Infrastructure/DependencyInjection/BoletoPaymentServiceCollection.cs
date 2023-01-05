using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    internal class BoletoPaymentServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IBoletoPaymentService, BoletoPaymentService>();
            services.AddScoped<IBoletoPaymentServiceFactory, BoletoPaymentServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IBoletoPaymentService, BoletoPaymentService>();
            services.AddSingleton<IBoletoPaymentServiceFactory, BoletoPaymentServiceFactory>();
        }
    }
}