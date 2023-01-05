using Microsoft.Extensions.DependencyInjection;

namespace Osb.Core.Webhook.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTransientMiddlewareFactories(this IServiceCollection services)
        {
            InputServiceCollection.AddTransientInputFactories(services);
            OutputServiceCollection.AddTransientOutputFactories(services);
            WebhookAuthenticationServiceCollection.AddTransientWebhookAuthenticationFactories(services);
        }
    }
}