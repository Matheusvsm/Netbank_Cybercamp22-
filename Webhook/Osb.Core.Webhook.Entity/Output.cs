using System;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Webhook.Entity
{
    public class Output : BaseEntity
    {
        public long? OutputLogId { get; set; }
        public long InputLogId { get; set; }
        public string Response { get; set; }
        public DateTime LogDate { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
    }
}