using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Factory.Service;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Repository;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class TaxPaymentServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ITaxPaymentService, TaxPaymentService>();
            services.AddScoped<ITaxPaymentServiceFactory, TaxPaymentServiceFactory>();
            services.AddScoped<ITaxPaymentRepository, TaxPaymentRepository>();
            services.AddScoped<ITaxPaymentRepositoryFactory, TaxPaymentRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ITaxPaymentService, TaxPaymentService>();
            services.AddSingleton<ITaxPaymentServiceFactory, TaxPaymentServiceFactory>();
            services.AddSingleton<ITaxPaymentRepository, TaxPaymentRepository>();
            services.AddSingleton<ITaxPaymentRepositoryFactory, TaxPaymentRepositoryFactory>();
        }
    }
}