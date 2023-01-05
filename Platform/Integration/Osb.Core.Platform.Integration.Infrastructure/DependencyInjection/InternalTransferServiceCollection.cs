using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    public class InternalTransferServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IInternalTransferService, InternalTransferService>();
            services.AddScoped<IInternalTransferServiceFactory, InternalTransferServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IInternalTransferService, InternalTransferService>();
            services.AddSingleton<IInternalTransferServiceFactory, InternalTransferServiceFactory>();
        }
    }
}