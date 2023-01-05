using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class UserAccount : BaseEntity
    {
        public long UserAccountId { get; set; }
        public long AccountId { get; set; }
        public long UserId { get; set; }

        public static UserAccount Create(long accountId, long userId)
        {
            return new UserAccount
            {
                AccountId = accountId,
                UserId = userId,
                CreationUserId = userId,
                UpdateUserId = userId 
            };
        }
    }
}