using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.LimitedAccount.Generate
{
    public class WorkerService
    {
        private readonly ILimitedAccountServiceFactory _limitedAccountServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(ILimitedAccountServiceFactory limitedAccountServiceFactory, IExceptionLogServiceFactory exceptionLogServiceFactory, Settings settings)
        {
            _limitedAccountServiceFactory = limitedAccountServiceFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            ILimitedAccountService limitedAccountService = _limitedAccountServiceFactory.Create();
            IEnumerable<BusinessModel.LimitedAccount> limitedAccountList = limitedAccountService.FindLimitedAccountListByStatus(LimitedAccountStatus.Created);

            foreach (BusinessModel.LimitedAccount limitedAccount in limitedAccountList)
            {
                try
                {
                    limitedAccountService.GenerateLimitedAccount(limitedAccount);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    limitedAccount.Attempts += 1;

                    if (limitedAccount.Attempts >= _settings.Attempts)
                        limitedAccount.Status = LimitedAccountStatus.Error;

                    limitedAccountService.Update(limitedAccount);
                }
            }
        }
    }
}
