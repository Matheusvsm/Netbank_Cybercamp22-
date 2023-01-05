using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class Operation : BaseEntity
    {
        public long OperationId { get; set; }
        public OperationType OperationType { get; set; }
        public long ExternalIdentifier { get; set; }

        public static Operation Create(long userId, OperationType operationType)
        {
            return new Operation
            {
                OperationType = operationType,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}