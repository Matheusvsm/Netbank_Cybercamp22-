using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class ActionFunction : BaseEntity
    {
        public long ActionFunctionId { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public long UserId { get; set; }

        public static ActionFunction Create(long userId, string action, string controller)
        {
            return new ActionFunction
            {
                Action = action,
                Controller = controller,
                UserId = userId,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }

}


