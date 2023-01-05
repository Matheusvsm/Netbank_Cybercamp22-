using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Webhook.Repository;

namespace Osb.Core.Webhook.Factory.Repository
{
    public class WebhookAuthenticationRepositoryFactory : Interfaces.IWebhookAuthenticationRepositoryFactory
    {
        private IServiceProvider _provider;

        public WebhookAuthenticationRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IWebhookAuthenticationRepository Create() => _provider.GetService<IWebhookAuthenticationRepository>();
    }
}
