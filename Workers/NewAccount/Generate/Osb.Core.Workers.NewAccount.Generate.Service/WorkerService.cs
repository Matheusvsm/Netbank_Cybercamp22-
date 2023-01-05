using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.NewAccount.Generate
{
    public class WorkerService
    {
        private readonly INewAccountServiceFactory _newAccountServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(INewAccountServiceFactory newAccountServiceFactory, IExceptionLogServiceFactory exceptionLogServiceFactory, Settings settings)
        {
            _newAccountServiceFactory = newAccountServiceFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            INewAccountService newAccountService = _newAccountServiceFactory.Create();
            IEnumerable<BusinessModel.NewAccount> newAccountList = newAccountService.FindNewAccountByStatus(NewAccountStatus.Created);

            foreach (BusinessModel.NewAccount newAccount in newAccountList)
            {
                try
                {
                    newAccountService.GenerateNewAccount(newAccount);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    newAccount.Attempts += 1;

                    if (newAccount.Attempts >= _settings.Attempts)
                        newAccount.Status = NewAccountStatus.Error;

                    newAccountService.Update(newAccount);
                }
            }
        }
    }
}