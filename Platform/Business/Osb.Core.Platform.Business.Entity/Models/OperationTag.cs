using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class OperationTag : BaseEntity
    {
        public long OperationTagId { get; set; }
        public long OperationId { get; set; }
        public string Tag { get; set; }

        public static OperationTag Create(long operationId, string tag, long userId)
        {
            return new OperationTag
            {
                OperationId = operationId,
                Tag = tag,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}