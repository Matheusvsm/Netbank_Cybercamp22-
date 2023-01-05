using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class Profile : BaseEntity
    {
        public long ProfileId { get; set; }
        public string Name { get; set; }

        public static Profile Create(long userId, string name)
        {
            return new Profile
            {
                Name = name,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}