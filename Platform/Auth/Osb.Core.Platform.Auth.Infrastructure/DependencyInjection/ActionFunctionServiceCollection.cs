using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Service;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Api.Repository;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Service;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository;

namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection
{
    internal class ActionFunctionServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IActionFunctionService, ActionFunctionService>();
            services.AddScoped<IActionFunctionServiceFactory, ActionFunctionServiceFactory>();
            services.AddScoped<IActionFunctionRepository, ActionFunctionRepository>();
            services.AddScoped<IActionFunctionRepositoryFactory, ActionFunctionRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IActionFunctionService, ActionFunctionService>();
            services.AddSingleton<IActionFunctionServiceFactory, ActionFunctionServiceFactory>();
            services.AddSingleton<IActionFunctionRepository, ActionFunctionRepository>();
            services.AddSingleton<IActionFunctionRepositoryFactory, ActionFunctionRepositoryFactory>();
        }
    }
}