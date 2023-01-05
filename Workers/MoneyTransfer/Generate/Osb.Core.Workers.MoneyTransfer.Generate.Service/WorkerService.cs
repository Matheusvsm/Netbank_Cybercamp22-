using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Business.Util;
using Osb.Core.Workers.MoneyTransfer.Generate.Util.Resources;

namespace Osb.Core.Workers.MoneyTransfer.Generate
{
    public class WorkerService
    {
        private readonly IMoneyTransferServiceFactory _moneyTransferServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly INotificationRepositoryFactory _notificationRepositoryFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;

        public WorkerService(IMoneyTransferServiceFactory moneyTransferServiceFactory, IExceptionLogServiceFactory exceptionLogServiceFactory, Settings settings, IAccountRepositoryFactory accountRepositoryFactory, INotificationRepositoryFactory notificationRepositoryFactory, IUserRepositoryFactory userRepositoryFactory)
        {
            _moneyTransferServiceFactory = moneyTransferServiceFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
            _accountRepositoryFactory = accountRepositoryFactory;
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _userRepositoryFactory = userRepositoryFactory;

        }

        public void Generate()
        {
            IMoneyTransferService moneyTransferService = _moneyTransferServiceFactory.Create();
            IEnumerable<BusinessModel.MoneyTransfer> moneyTransferList = moneyTransferService.FindMoneyTransferListByStatus(MoneyTransferStatus.Created);

            foreach (BusinessModel.MoneyTransfer moneyTransfer in moneyTransferList)
            {
                try
                {
                    moneyTransferService.GenerateMoneyTransfer(moneyTransfer);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    moneyTransfer.Attempts += 1;

                    if (moneyTransfer.Attempts >= _settings.Attempts)
                    {
                        moneyTransfer.Status = MoneyTransferStatus.Error;

                        IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                        Account account = accountRepository.GetById(moneyTransfer.FromAccountId);

                        INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
                        
                        IUserRepository userRepository = _userRepositoryFactory.Create();
                        UserInformation userInformation = userRepository.GetByUserId(moneyTransfer.CreationUserId);

                        if (_settings.AttemptEmailLimitNotification)
                            Notification.SendMail(account.CompanyId, userInformation, notificationRepository, MoneyTransferExcMsg.EXC0001, MoneyTransferExcMsg.EXC0002);

                        if (_settings.AttemptSmsLimitNotification)
                            Notification.SendSms(account.CompanyId, userInformation, notificationRepository, MoneyTransferExcMsg.EXC0002);

                        if (_settings.AttemptPushLimitNotification)
                            Notification.SendPush(account.CompanyId, moneyTransfer.OperationId, userInformation, notificationRepository, MoneyTransferExcMsg.EXC0001, MoneyTransferExcMsg.EXC0002);
                    }                    

                    moneyTransferService.Update(moneyTransfer);
                }
            }
        }
    }
}
