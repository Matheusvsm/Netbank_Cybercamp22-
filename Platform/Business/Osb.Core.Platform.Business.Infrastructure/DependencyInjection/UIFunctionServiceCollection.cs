using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class UIFunctionServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IUIFunctionRepository, UIFunctionRepository>();
            services.AddScoped<IUIFunctionRepositoryFactory, UIFunctionRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IUIFunctionRepository, UIFunctionRepository>();
            services.AddSingleton<IUIFunctionRepositoryFactory, UIFunctionRepositoryFactory>();
        }
    }
}