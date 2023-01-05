using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Api.Factory.Repository;
using Osb.Core.Api.Factory.Repository.Interfaces;
using Osb.Core.Api.Repository;

namespace Osb.Core.Api.Infrastructure.DependencyInjection
{
    internal class ActionFunctionServiceCollection
    {
        public static void AddTransientActionFunctionFactories(IServiceCollection services)
        {
            services.AddTransient<IActionFunctionRepository, ActionFunctionRepository>();
            services.AddTransient<IActionFunctionRepositoryFactory, ActionFunctionRepositoryFactory>();
        }
    }
}