using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Factory.Repository;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Service;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Auth.Service;
using Osb.Core.Platform.Auth.Service.Interfaces;


namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection.Extensions
{
    internal class DeviceServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddTransient<IDeviceServiceFactory, DeviceServiceFactory>();
            services.AddTransient<IDeviceService, NotificationService>();
            services.AddScoped<IDeviceRepositoryFactory, DeviceRepositoryFactory>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {

            services.AddTransient<IDeviceServiceFactory, DeviceServiceFactory>();
            services.AddTransient<IDeviceService, NotificationService>();
            services.AddScoped<IDeviceRepositoryFactory, DeviceRepositoryFactory>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
        }

        public static void AddTransientFactories(IServiceCollection services)
        {
            services.AddTransient<IDeviceServiceFactory, DeviceServiceFactory>();
            services.AddTransient<IDeviceService, NotificationService>();
        }
    }
}