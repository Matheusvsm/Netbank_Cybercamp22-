using Osb.Core.Platform.Common.Entity.Models;
using System;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class SmsNotification : BaseEntity
    {
        public long SmsNotificationId { get; set; }
        public long CompanyId { get; set; }
        public string PhoneTo { get; set; }
        public string Content { get; set; }
        public SendStatus SendStatus { get; set; }
        public DateTime SentDate { get; set; }
        public int Attempts { get; set; }

        public static SmsNotification Create(long userId, long companyId, string phoneTo, string content)
        {
            return new SmsNotification
            {
                CompanyId = companyId,
                PhoneTo = phoneTo,
                Content = content,
                SendStatus = SendStatus.Create,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}