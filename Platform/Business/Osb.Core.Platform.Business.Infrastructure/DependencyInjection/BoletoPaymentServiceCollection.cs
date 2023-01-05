using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Service;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class BoletoPaymentServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IBoletoPaymentService, BoletoPaymentService>();
            services.AddScoped<IBoletoPaymentServiceFactory, BoletoPaymentServiceFactory>();
            services.AddScoped<IBoletoPaymentRepository, BoletoPaymentRepository>();
            services.AddScoped<IBoletoPaymentRepositoryFactory, BoletoPaymentRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IBoletoPaymentService, BoletoPaymentService>();
            services.AddSingleton<IBoletoPaymentServiceFactory, BoletoPaymentServiceFactory>();
            services.AddSingleton<IBoletoPaymentRepository, BoletoPaymentRepository>();
            services.AddSingleton<IBoletoPaymentRepositoryFactory, BoletoPaymentRepositoryFactory>();
        }
    }
}