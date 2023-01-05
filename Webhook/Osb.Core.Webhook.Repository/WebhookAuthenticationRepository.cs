using System.Collections.Generic;
using Osb.Core.Webhook.Entity;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;

namespace Osb.Core.Webhook.Repository
{
    public class WebhookAuthenticationRepository : IWebhookAuthenticationRepository
    {
        private IDbContext<WebhookAuthentication> _context;
        public WebhookAuthenticationRepository(IDbContext<WebhookAuthentication> context)
        {
            _context = context;
        }

        public WebhookAuthentication GetByCompanyId(long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = companyId,
            };

            WebhookAuthentication companyAuthentication = _context.ExecuteWithSingleResult("getwebhookauthenticationbycompanyid", parameters);

            return companyAuthentication;
        }
    }
}