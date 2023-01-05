using System;
using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IDbContext<SmsNotification> _smsNotificationContext;
        private readonly IDbContext<MailNotification> _mailNotificationContext;
        private readonly IDbContext<Device> _notificationContext;
        private readonly IDbContext<PushNotification> _pushNotificationContext;

        public NotificationRepository(IDbContext<SmsNotification> smsNotificationContext, IDbContext<MailNotification> mailNotificationContext, IDbContext<Device> notificationContext, IDbContext<PushNotification> pushNotificationContext)
        {
            this._smsNotificationContext = smsNotificationContext;
            this._mailNotificationContext = mailNotificationContext;
            this._notificationContext = notificationContext;
            this._pushNotificationContext = pushNotificationContext;
        }

        public IEnumerable<SmsNotification> FindSmsListBySendStatus(SendStatus sendStatus)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramSendStatus"] = sendStatus
            };

            IEnumerable<SmsNotification> smsNotificationList = _smsNotificationContext.ExecuteWithMultipleResults("GetSmsListByStatus", parameters);

            return smsNotificationList;
        }

        public IEnumerable<MailNotification> FindMailListBySendStatus(SendStatus sendStatus)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramSendStatus"] = sendStatus
            };

            IEnumerable<MailNotification> mailNotificationList = _mailNotificationContext.ExecuteWithMultipleResults("GetMailListByStatus", parameters);

            return mailNotificationList;
        }

        public IEnumerable<PushNotification> FindPushNotificationListByStatus(PushNotificationStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            IEnumerable<PushNotification> pushNotificationList = _pushNotificationContext.ExecuteWithMultipleResults("GetPushNotificationListByStatus", parameters);

            return pushNotificationList;
        }

        public void Save(SmsNotification smsNotification, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = smsNotification.CompanyId,
                ["paramPhoneTo"] = smsNotification.PhoneTo,
                ["paramContent"] = smsNotification.Content,
                ["paramSendStatus"] = smsNotification.SendStatus,
                ["paramUserId"] = smsNotification.CreationUserId
            };

            _smsNotificationContext.ExecuteWithNoResult("InsertSmsNotification", parameters, transactionScope);
        }

        public void Save(MailNotification mailNotification, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = mailNotification.CompanyId,
                ["paramMailTo"] = mailNotification.MailTo,
                ["paramContent"] = mailNotification.Content,
                ["paramSendStatus"] = mailNotification.SendStatus,
                ["paramSubject"] = mailNotification.Subject,
                ["paramUserId"] = mailNotification.CreationUserId
            };

            _mailNotificationContext.ExecuteWithNoResult("InsertMailNotification", parameters, transactionScope);
        }

        public void Save(PushNotification pushNotification, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramOperationId"] = pushNotification.OperationId,
                ["paramUserId"] = pushNotification.UserId,
                ["paramCompanyId"] = pushNotification.CompanyId,
                ["paramTitle"] = pushNotification.Title,
                ["paramBody"] = pushNotification.Body,
                ["paramStatus"] = pushNotification.Status,
                ["paramSendDate"] = pushNotification.SendDate
            };

            _pushNotificationContext.ExecuteWithNoResult("InsertPushNotification", parameters, transactionScope);
        }

        public void Update(SmsNotification smsNotification)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramSmsNotificationId"] = smsNotification.SmsNotificationId,
                ["paramAttempts"] = smsNotification.Attempts,
                ["paramSendStatus"] = smsNotification.SendStatus,
                ["paramUserId"] = smsNotification.UpdateUserId
            };

            _smsNotificationContext.ExecuteWithNoResult("UpdateSmsNotification", parameters);
        }

        public void Update(MailNotification mailNotification)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramMailNotificationId"] = mailNotification.MailNotificationId,
                ["paramSendStatus"] = mailNotification.SendStatus,
                ["paramAttempts"] = mailNotification.Attempts,
                ["paramUserId"] = mailNotification.UpdateUserId
            };

            _mailNotificationContext.ExecuteWithNoResult("UpdateMailNotification", parameters);
        }

        public void Update(PushNotification pushNotification)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramPushNotificationId"] = pushNotification.PushNotificationId,
                ["paramTitle"] = pushNotification.Title,
                ["paramBody"] = pushNotification.Body,
                ["paramStatus"] = pushNotification.Status,
                ["paramSendDate"] = pushNotification.SendDate,
                ["paramAttempts"] = pushNotification.Attempts,
                ["paramUserId"] = pushNotification.UserId
            };

            _pushNotificationContext.ExecuteWithNoResult("UpdatePushNotification", parameters);
        }

        public Device GetDeviceByUserIdAndCompanyId(long userId, long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId,
                ["paramCompanyId"] = companyId
            };

            Device device = _notificationContext.ExecuteWithSingleResult("GetDeviceByUserIdAndCompanyId", parameters);

            return device;
        }

        public PushNotification GetByOperationId(long operationId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramOperationId"] = operationId,
            };

            PushNotification pushNotification = _pushNotificationContext.ExecuteWithSingleResult("GetPushNotificationByOperationId", parameters);

            return pushNotification;
        }
    }
}