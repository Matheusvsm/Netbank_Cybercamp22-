using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Webhook.Entity
{
    public class WebhookAuthentication : BaseEntity
    {
        public long WebhookAuthenticationId { get; set; }
        public long CompanyId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}