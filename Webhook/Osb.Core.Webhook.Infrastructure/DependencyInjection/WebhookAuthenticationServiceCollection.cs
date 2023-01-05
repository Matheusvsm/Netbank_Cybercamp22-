using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Webhook.Factory.Repository.Interfaces;
using Osb.Core.Webhook.Repository;
using Osb.Core.Webhook.Factory.Repository;

namespace Osb.Core.Webhook.Infrastructure.DependencyInjection
{
    internal class WebhookAuthenticationServiceCollection
    {
        public static void AddTransientWebhookAuthenticationFactories(IServiceCollection services)
        {
            services.AddTransient<IWebhookAuthenticationRepository, WebhookAuthenticationRepository>();
            services.AddTransient<IWebhookAuthenticationRepositoryFactory, WebhookAuthenticationRepositoryFactory>();
        }
    }
}
