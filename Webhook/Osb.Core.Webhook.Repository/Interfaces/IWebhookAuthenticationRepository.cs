using Osb.Core.Webhook.Entity;

namespace Osb.Core.Webhook.Repository
{
    public interface IWebhookAuthenticationRepository
    {
        WebhookAuthentication GetByCompanyId(long companyId);

    }
}