using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class User : BaseEntity
    {
        public long UserId { get; set; }
        public string Login { get; set; }
        public int LoginAttempts { get; set; }
        public UserStatus Status { get; set; }
        public bool IsFirstAccess { get; set; }
        public bool AcceptedTerms { get; set; }

        public static User Create(string login, bool isFirstAccess)
        {
            return new User
            {
                Login = login,
                IsFirstAccess = isFirstAccess,
                Status = UserStatus.Active
            };
        }
    }
}