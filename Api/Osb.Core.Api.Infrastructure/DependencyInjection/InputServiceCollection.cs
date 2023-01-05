using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Api.Factory.Repository.Interfaces;
using Osb.Core.Api.Repository;
using Osb.Core.Api.Factory.Repository;

namespace Osb.Core.Api.Infrastructure.DependencyInjection
{
    internal class InputServiceCollection
    {
        public static void AddTransientInputFactories(IServiceCollection services)
        {
            services.AddTransient<IInputRepository, InputRepository>();
            services.AddTransient<IInputRepositoryFactory, InputRepositoryFactory>();
        }
    }
}
