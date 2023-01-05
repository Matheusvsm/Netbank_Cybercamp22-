using System.Collections.Generic;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Workers.UserHook.Generate.Service.Mapping;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using System;
using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Workers.PendingUser.Generate
{
    public class WorkerService
    {
        private readonly IUserServiceFactory _userServiceFactory;

        private readonly IAccountServiceFactory _accountServiceFactory;
        private readonly ILimitedAccountServiceFactory _limitedAccountServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private IConnectionFactory _connectionFactory;
        private readonly Settings _settings;
        private readonly Mapper _mapper;

        public WorkerService(
            IUserServiceFactory userServiceFactory,
            IAccountServiceFactory accountServiceFactory,
            Settings settings,
            ILimitedAccountServiceFactory limitedAccountServiceFactory,
            IConnectionFactory connectionFactory,
            IExceptionLogServiceFactory exceptionLogServiceFactory
            )
        {
            _userServiceFactory = userServiceFactory;
            _accountServiceFactory = accountServiceFactory;
            _limitedAccountServiceFactory = limitedAccountServiceFactory;
            _connectionFactory = connectionFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
            _mapper = new Mapper();
        }

        public void Generate()
        {
            ILimitedAccountService limitedAccountService = _limitedAccountServiceFactory.Create();
            IUserService userService = _userServiceFactory.Create();
            IAccountService accountService = _accountServiceFactory.Create();

            Account account = null;

            IEnumerable<LimitedAccount> limitedAccountList = limitedAccountService.FindLimitedAccountListByStatus(LimitedAccountStatus.PendingUser);

            foreach (LimitedAccount limitedAccount in limitedAccountList)
            {
                account = accountService.FindAccountByAccountKey(limitedAccount.AccountKey);

                if (account != null)
                {
                    TransactionScope transactionScope = _connectionFactory.CreateTransaction();

                    try
                    {
                        UserWebhookRequest webhookRequest = _mapper.Map(limitedAccount);

                        userService.UserWebhookHandler(webhookRequest);

                        limitedAccount.Status = LimitedAccountStatus.Registered;
                        limitedAccountService.Update(limitedAccount, transactionScope);

                        transactionScope.Transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                        exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                        transactionScope.Transaction.Rollback();
                    }
                    finally
                    {
                        transactionScope.Connection.Close();
                    }
                }
                else
                    continue;
            }
        }
    }
}
