using System;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class AuthorizationToken : BaseEntity
    {
        public long AuthorizationTokenId { get; set; }
        public long? UserId { get; set; }
        public long? AccountId { get; set; }
        public string TaxId { get; set; }
        public string Code { get; set; }
        public string Salt { get; set; }
        public DateTime ExpirationDate { get; set; }
        public AuthorizationTokenStatus Status { get; set; }
        public byte ValidateAttempts { get; set; }
    }
}