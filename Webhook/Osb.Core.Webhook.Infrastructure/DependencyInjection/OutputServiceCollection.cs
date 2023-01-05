using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Webhook.Factory.Repository.Interfaces;
using Osb.Core.Webhook.Repository;
using Osb.Core.Webhook.Factory.Repository;

namespace Osb.Core.Webhook.Infrastructure.DependencyInjection
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
