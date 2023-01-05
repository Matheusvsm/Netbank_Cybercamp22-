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
using Osb.Core.Workers.InternalTransfer.Generate.Util.Resources;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.InternalTransfer.Generate
{
    public class WorkerService
    {
        private readonly IInternalTransferServiceFactory _internalTransferServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        public readonly INotificationRepositoryFactory _notificationRepositoryFactory;
        private readonly Settings _settings;

        public WorkerService(IInternalTransferServiceFactory internalTransferServiceFactory,
                             IUserRepositoryFactory userRepositoryFactory,
                             IAccountRepositoryFactory accountRepositoryFactory,
                             INotificationRepositoryFactory notificationRepositoryFactory,
                             IExceptionLogServiceFactory exceptionLogServiceFactory, Settings settings)
        {
            _internalTransferServiceFactory = internalTransferServiceFactory;
            _userRepositoryFactory = userRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;

        }

        public void Generate()
        {
            IInternalTransferService internalTransferService = _internalTransferServiceFactory.Create();
            IEnumerable<BusinessModel.InternalTransfer> internalTransferList = internalTransferService.FindInternalTransferListByStatus(InternalTransferStatus.Created);

            foreach (BusinessModel.InternalTransfer internalTransfer in internalTransferList)
            {
                try
                {
                    internalTransferService.GenerateInternalTransfer(internalTransfer);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    internalTransfer.Attempts += 1;

                    if (internalTransfer.Attempts >= _settings.Attempts)
                    {
                        internalTransfer.Status = InternalTransferStatus.Error;

                        IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                        Account account = accountRepository.GetById(internalTransfer.FromAccountId);

                        INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
                        IUserRepository userRepository = _userRepositoryFactory.Create();
                        UserInformation userInformation = userRepository.GetByUserId(internalTransfer.CreationUserId);

                        if (_settings.AttemptEmailLimitNotification)
                            Notification.SendMail(account.CompanyId, userInformation, notificationRepository, InternalTransferExcMsg.EXC0001, InternalTransferExcMsg.EXC0002);

                        if (_settings.AttemptSmsLimitNotification)
                            Notification.SendSms(account.CompanyId, userInformation, notificationRepository, InternalTransferExcMsg.EXC0002);

                        if (_settings.AttemptPushLimitNotification)
                            Notification.SendPush(account.CompanyId, internalTransfer.OperationId, userInformation, notificationRepository, InternalTransferExcMsg.EXC0001, InternalTransferExcMsg.EXC0002);
                    }

                    internalTransferService.Update(internalTransfer);
                }
            }
        }
    }
}
