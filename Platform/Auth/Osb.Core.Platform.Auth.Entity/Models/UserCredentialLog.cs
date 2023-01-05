using System;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class UserCredentialLog : BaseEntity
    {        
        public string Login { get; set; }
        public DateTime LogDate { get; set; }
        public long UserId { get; set; }        
    }
}

