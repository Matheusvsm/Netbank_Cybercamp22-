using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Webhook.Factory.Repository.Interfaces;
using Osb.Core.Webhook.Repository;
using Osb.Core.Webhook.Factory.Repository;

namespace Osb.Core.Webhook.Infrastructure.DependencyInjection
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
