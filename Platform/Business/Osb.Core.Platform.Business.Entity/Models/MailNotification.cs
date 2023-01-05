using Osb.Core.Platform.Common.Entity.Models;
using System;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class MailNotification : BaseEntity
    {
        public long MailNotificationId { get; set; }
        public long CompanyId { get; set; }
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public SendStatus SendStatus { get; set; }
        public DateTime SentDate { get; set; }
        public int Attempts { get; set; }

        public static MailNotification Create(long userId, long companyId, string mailTo, string subject, string content)
        {
            return new MailNotification
            {
                CompanyId = companyId,
                MailTo = mailTo,
                Subject = subject,
                Content = content,
                SendStatus = SendStatus.Create,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}