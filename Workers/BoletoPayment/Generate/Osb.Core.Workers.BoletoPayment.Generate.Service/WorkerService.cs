using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Business.Util;
using Osb.Core.Workers.BoletoPayment.Generate.Util.Resources;

namespace Osb.Core.Workers.BoletoPayment.Generate
{
    public class WorkerService
    {
        private readonly IBoletoPaymentServiceFactory _boletoPaymentServiceFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        public readonly INotificationRepositoryFactory _notificationRepositoryFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(IBoletoPaymentServiceFactory boletoPaymentServiceFactory, IUserRepositoryFactory userRepositoryFactory, IAccountRepositoryFactory accountRepositoryFactory, INotificationRepositoryFactory notificationRepositoryFactory, IExceptionLogServiceFactory exceptionLogServiceFactory, Settings settings)
        {
            _boletoPaymentServiceFactory = boletoPaymentServiceFactory;
            _userRepositoryFactory = userRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            IBoletoPaymentService boletoPaymentService = _boletoPaymentServiceFactory.Create();
            IEnumerable<BusinessModel.BoletoPayment> boletoPaymentList = boletoPaymentService.FindBoletoPaymentListByStatus(BoletoPaymentStatus.Created);

            foreach (BusinessModel.BoletoPayment boletoPayment in boletoPaymentList)
            {
                try
                {
                    boletoPaymentService.GenerateBoletoPayment(boletoPayment);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    boletoPayment.Attempts += 1;

                    if (boletoPayment.Attempts >= _settings.Attempts)
                    {
                        boletoPayment.Status = BoletoPaymentStatus.Error;

                        IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                        Account account = accountRepository.GetById(boletoPayment.AccountId);

                        IUserRepository userRepository = _userRepositoryFactory.Create();
                        UserInformation userInformation = userRepository.GetByUserId(boletoPayment.CreationUserId);

                        INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();

                        if (_settings.AttemptEmailLimitNotification)
                            Notification.SendMail(account.CompanyId, userInformation, notificationRepository, BoletoPaymentExcMsg.EXC0001, BoletoPaymentExcMsg.EXC0002);

                        if (_settings.AttemptSmsLimitNotification)
                            Notification.SendSms(account.CompanyId, userInformation, notificationRepository, BoletoPaymentExcMsg.EXC0002);

                        if (_settings.AttemptPushLimitNotification)
                            Notification.SendPush(account.CompanyId, boletoPayment.OperationId, userInformation, notificationRepository, BoletoPaymentExcMsg.EXC0001, BoletoPaymentExcMsg.EXC0002);
                    }

                    boletoPaymentService.UpdateBoletoPayment(boletoPayment);
                }
            }
        }
    }
}