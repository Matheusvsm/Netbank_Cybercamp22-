using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface INotificationRepository
    {
        IEnumerable<SmsNotification> FindSmsListBySendStatus(SendStatus sendStatus);
        IEnumerable<MailNotification> FindMailListBySendStatus(SendStatus sendStatus);
        IEnumerable<PushNotification> FindPushNotificationListByStatus(PushNotificationStatus status);
        Device GetDeviceByUserIdAndCompanyId(long userId, long CompanyId);
        PushNotification GetByOperationId(long operationId);
        void Save(SmsNotification smsNotification, TransactionScope transactionScope = null);
        void Save(MailNotification mailNotification, TransactionScope transactionScope = null);
        void Save(PushNotification pushNotification, TransactionScope transactionScope = null);
        void Update(SmsNotification smsNotification);
        void Update(MailNotification mailNotification);
        void Update(PushNotification pushNotification);
    }
}