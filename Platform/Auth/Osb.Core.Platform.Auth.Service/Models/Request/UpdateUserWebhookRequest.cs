using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class UpdateUserWebhookRequest
    {
        public long? UserWebhookId { get; set; }
        public WebhookStatus Status { get; set; }
    }
}