using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class RememberLoginToken : BaseEntity
    {
        public long RememberLoginTokenId { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public string HashTokenAccess { get; set; }
        public string TokenAccess { get; set; }

        public static RememberLoginToken Create(long rememberLoginTokenId, long userId, long companyId, string hashTokenAccess, string tokenAccess)
        {
            return new RememberLoginToken
            {
                RememberLoginTokenId = rememberLoginTokenId,
                UserId = userId,
                CompanyId = companyId,
                HashTokenAccess = hashTokenAccess,
                TokenAccess = tokenAccess,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}