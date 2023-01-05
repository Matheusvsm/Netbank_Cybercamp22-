using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Webhook.Entity
{
    public class Input : BaseEntity
    {
        public long InputLogId { get; set; }
        public string Body { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
        public string Headers { get; set; }
    }
}