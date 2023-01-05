using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using BusinessEntity = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface INotificationService
    {
        void SendSms(SmsNotification smsNotification);
        void SendMail(MailNotification mailNotification);
        void SendPushNotification(PushNotification pushNotification);
        IEnumerable<BusinessEntity.SmsNotification> FindSendSmsNotificationBySendStatus(SendStatus sendStatus);
        IEnumerable<BusinessEntity.MailNotification> FindSendMailNotificationBySendStatus(SendStatus sendStatus);
        IEnumerable<BusinessEntity.PushNotification> FindPushNotificationByStatus(PushNotificationStatus status);
        void Update(SmsNotification smsNotification);
        void Update(MailNotification mailNotification);
        void Update(PushNotification pushNotification);
        void Save(string mail, string phoneNumber, string subject, string content, long companyId, SendType? sendType = null, TransactionScope transactionScope = null);

    }
}