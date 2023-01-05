using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Api.Factory.Repository.Interfaces;
using Osb.Core.Api.Repository;
using Osb.Core.Api.Factory.Repository;

namespace Osb.Core.Api.Infrastructure.DependencyInjection
{
    internal class OutputServiceCollection
    {
        public static void AddTransientOutputFactories(IServiceCollection services)
        {
            services.AddTransient<IOutputRepository, OutputRepository>();
            services.AddTransient<IOutputRepositoryFactory, OutputRepositoryFactory>();
        }
    }
}
