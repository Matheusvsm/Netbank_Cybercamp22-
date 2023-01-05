using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class PushNotification : BaseEntity
    {
        public long PushNotificationId { get; set; }
        public long? OperationId { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public PushNotificationStatus Status { get; set; }
        public DateTime? SendDate { get; set; }
        public int Attempts { get; set; }

        public static PushNotification Create(long? operationId, long userId, long companyId, string title, string body, PushNotificationStatus status)
        {
            return new PushNotification
            {
                OperationId = operationId,
                UserId = userId,
                CompanyId = companyId,
                Title = title,
                Body = body,
                Status = status,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}