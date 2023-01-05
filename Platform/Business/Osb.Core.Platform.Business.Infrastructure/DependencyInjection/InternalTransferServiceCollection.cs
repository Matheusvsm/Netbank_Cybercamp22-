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
    internal class InternalTransferServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IInternalTransferService, InternalTransferService>();
            services.AddScoped<IInternalTransferServiceFactory, InternalTransferServiceFactory>();
            services.AddScoped<IInternalTransferRepository, InternalTransferRepository>();
            services.AddScoped<IInternalTransferRepositoryFactory, InternalTransferRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IInternalTransferServiceFactory, InternalTransferServiceFactory>();
            services.AddSingleton<IInternalTransferService, InternalTransferService>();
            services.AddSingleton<IInternalTransferRepositoryFactory, InternalTransferRepositoryFactory>();
            services.AddSingleton<IInternalTransferRepository, InternalTransferRepository>();
        }
    }
}