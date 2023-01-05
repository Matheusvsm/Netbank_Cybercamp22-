using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Factory.Service;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
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