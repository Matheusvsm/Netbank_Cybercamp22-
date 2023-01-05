using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.TopUp.Authorize
{
    public class WorkerService
    {
        private readonly ITopUpServiceFactory _topUpServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(ITopUpServiceFactory topUpServiceFactory, IExceptionLogServiceFactory exceptionLogServiceFactory, Settings settings)
        {
            _topUpServiceFactory = topUpServiceFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Authorize()
        {
            ITopUpService topUpService = _topUpServiceFactory.Create();
            IEnumerable<BusinessModel.TopUp> topUpToList = topUpService.FindTopUpListByStatus(TopUpStatus.CanBeRegister);

            foreach (BusinessModel.TopUp topUp in topUpToList)
            {
                try
                {
                    topUpService.AuthorizeTopUp(topUp);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    topUp.Attempts += 1;

                    if (topUp.Attempts >= _settings.Attempts)
                        topUp.Status = TopUpStatus.Error;

                    topUpService.Update(topUp);
                }
            }
        }
    }
}