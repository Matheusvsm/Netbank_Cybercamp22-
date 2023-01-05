using System;
using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Util;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Workers.Pix.GeneratePixOut.Util.Resources;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.Pix.GeneratePixOut.Service
{
    public class WorkerService
    {
        private readonly IPixServiceFactory _pixServiceFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        public readonly INotificationRepositoryFactory _notificationRepositoryFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(IPixServiceFactory pixServiceFactory, IUserRepositoryFactory userRepositoryFactory, IAccountRepositoryFactory accountRepositoryFactory, INotificationRepositoryFactory notificationRepositoryFactory, IExceptionLogServiceFactory exceptionLogServiceFactory, Settings settings)
        {
            _pixServiceFactory = pixServiceFactory;
            _userRepositoryFactory = userRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            IPixService pixService = _pixServiceFactory.Create();
            IEnumerable<BusinessModel.PixOut> pixOutList = pixService.FindPixOutByStatus(PixOutStatus.Created);

            foreach (BusinessModel.PixOut pixOut in pixOutList)
            {
                try
                {
                    pixService.GeneratePixOut(pixOut);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    pixOut.Attempts += 1;

                    if (pixOut.Attempts >= _settings.Attempts)
                    {
                        pixOut.Status = PixOutStatus.Error;

                        IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                        Account account = accountRepository.GetById(pixOut.AccountId);

                        INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
                        IUserRepository userRepository = _userRepositoryFactory.Create();
                        UserInformation userInformation = userRepository.GetByUserId(pixOut.CreationUserId);

                        if (_settings.AttemptEmailLimitNotification)
                            Notification.SendMail(account.CompanyId, userInformation, notificationRepository, PixExcMsg.EXC0001, PixExcMsg.EXC0002);

                        if (_settings.AttemptSmsLimitNotification)
                            Notification.SendSms(account.CompanyId, userInformation, notificationRepository, PixExcMsg.EXC0002);

                        if (_settings.AttemptPushLimitNotification)
                            Notification.SendPush(account.CompanyId, pixOut.OperationId, userInformation, notificationRepository, PixExcMsg.EXC0001, PixExcMsg.EXC0002);
                    }

                    pixService.UpdatePixOut(pixOut);
                }
            }
        }
    }
}
