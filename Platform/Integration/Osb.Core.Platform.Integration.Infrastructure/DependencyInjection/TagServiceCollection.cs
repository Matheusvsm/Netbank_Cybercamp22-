using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    public class TagServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagServiceFactory, TagServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ITagService, TagService>();
            services.AddSingleton<ITagServiceFactory, TagServiceFactory>();
        }
    }
}