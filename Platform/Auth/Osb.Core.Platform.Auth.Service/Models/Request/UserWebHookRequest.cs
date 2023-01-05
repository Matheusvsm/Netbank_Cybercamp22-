using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Enums;
namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class UserWebhookRequest
    {
        public long CompanyId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public EventType EventType { get; set; }
        public bool LockedUser { get; set; }
        public List<string> AccountKeyList { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}