using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Service;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class AddressServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressServiceFactory, AddressServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IAddressService, AddressService>();
            services.AddSingleton<IAddressServiceFactory, AddressServiceFactory>();
        }
    }
}