using System;
using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity;
using BusinessEntity = Osb.Core.Platform.Business.Entity.Models;
using IntegrationFactory = Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using System.Threading.Tasks;

namespace Osb.Core.Workers.Notification.Generate
{
    public class WorkerService
    {
        private readonly SendNotificationMapper _mapper;
        private readonly IntegrationFactory.INotificationServiceFactory _notificationServiceFactory;
        private readonly INotificationServiceFactory _notificationServiceFactoryBusiness;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private IConnectionFactory _connectionFactory;
        private readonly Settings _settings;

        public WorkerService(
            IntegrationFactory.INotificationServiceFactory notificationServiceFactory,
            IConnectionFactory connectionFactory,
            INotificationServiceFactory notificationServiceFactoryBusiness,
            IExceptionLogServiceFactory exceptionLogServiceFactory,
            Settings settings
        )
        {
            _mapper = new SendNotificationMapper();
            _notificationServiceFactory = notificationServiceFactory;
            _connectionFactory = connectionFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _notificationServiceFactoryBusiness = notificationServiceFactoryBusiness;
            _settings = settings;
        }

        public void Generate()
        {
            Parallel.Invoke(
                () => { SendSms(); },
                () => { SendSMail(); },
                () => SendPush());
        }

        public void SendSms()
        {
            INotificationService notificationService = _notificationServiceFactoryBusiness.Create();
            IEnumerable<BusinessEntity.SmsNotification> smsNotificationList = notificationService.FindSendSmsNotificationBySendStatus(SendStatus.Create);

            foreach (BusinessEntity.SmsNotification smsNotification in smsNotificationList)
            {
                try
                {
                    notificationService.SendSms(smsNotification);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    smsNotification.Attempts += 1;

                    if (smsNotification.Attempts >= _settings.Attempts)
                        smsNotification.SendStatus = SendStatus.Error;

                    notificationService.Update(smsNotification);
                }
            }
        }

        public void SendSMail()
        {
            INotificationService notificationService = _notificationServiceFactoryBusiness.Create();
            IEnumerable<BusinessEntity.MailNotification> mailNotificationList = notificationService.FindSendMailNotificationBySendStatus(SendStatus.Create);


            foreach (BusinessEntity.MailNotification mailNotification in mailNotificationList)
            {
                try
                {
                    notificationService.SendMail(mailNotification);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    mailNotification.Attempts += 1;

                    if (mailNotification.Attempts >= _settings.Attempts)
                        mailNotification.SendStatus = SendStatus.Error;

                    notificationService.Update(mailNotification);
                }
            }
        }

        public void SendPush()
        {
            INotificationService notificationService = _notificationServiceFactoryBusiness.Create();
            IEnumerable<BusinessEntity.PushNotification> pushNotificationList = notificationService.FindPushNotificationByStatus(PushNotificationStatus.CanBeSent);

            foreach (BusinessEntity.PushNotification pushNotification in pushNotificationList)
            {
                try
                {
                    notificationService.SendPushNotification(pushNotification);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    pushNotification.Attempts += 1;

                    if (pushNotification.Attempts >= _settings.Attempts)
                        pushNotification.Status = PushNotificationStatus.Error;

                    notificationService.Update(pushNotification);
                }
            }
        }
    }
}


