using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class ProfileActionFunction : BaseEntity
    {
        public long ProfileActionFunctionId { get; set; }
        public long ProfileId { get; set; }
        public long ActionFunctionId { get; set; }
        public long UserId { get; set; }

        public static ProfileActionFunction Create(long profileId, long actionFunctionId, long userId)
        {
            return new ProfileActionFunction
            {
                ProfileId = profileId,
                ActionFunctionId = actionFunctionId,
                UserId = userId,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}