using System;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class AccountLog : BaseEntity
    {
        public long AccountLogId { get; set; }
        public string Login { get; set; }
        public DateTime  LogDate { get; set; }
        public long UserId { get; set; }
    }
}