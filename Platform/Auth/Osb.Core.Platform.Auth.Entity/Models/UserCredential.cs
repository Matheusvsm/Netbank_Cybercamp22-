using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class UserCredential : BaseEntity
    {
        public long UserCredentialId { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public static UserCredential Create(long userId, string password, string salt)
        {
            return new UserCredential
            {
                UserId = userId,
                Password = password,
                Salt = salt,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}