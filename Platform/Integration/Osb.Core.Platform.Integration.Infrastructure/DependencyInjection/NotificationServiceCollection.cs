using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Repository;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Repository;
using Osb.Core.Platform.Integration.Repository.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    public class NotificationServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationServiceFactory, NotificationServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddSingleton<INotificationServiceFactory, NotificationServiceFactory>();
        }
    }
}