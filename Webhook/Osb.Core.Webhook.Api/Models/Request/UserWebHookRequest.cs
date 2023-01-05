using System.Collections.Generic;

namespace Osb.Core.Webhook.Api.Models.Request
{
    public class UserWebhookRequest : BaseRequest
    {
        public string UserTaxNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public int EventType { get; set; }
        public bool LockedUser { get; set; }
        public List<string> AccountKeyList { get; set; }
    }
}