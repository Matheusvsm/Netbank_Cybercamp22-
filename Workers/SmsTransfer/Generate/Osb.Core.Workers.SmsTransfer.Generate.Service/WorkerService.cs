using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.SmsTransfer.Generate
{
    public class WorkerService
    {
        private readonly IInternalTransferServiceFactory _internalTransferFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(IInternalTransferServiceFactory internalTransferFactory, IExceptionLogServiceFactory exceptionLogServiceFactory, Settings settings)
        {
            _internalTransferFactory = internalTransferFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            IInternalTransferService internalTransferService = _internalTransferFactory.Create();
            IEnumerable<BusinessModel.PendingInternalTransfer> pendingInternalTransferList = internalTransferService.FindPendingInternalTransferListByStatus(PendingInternalTransferStatus.Created);

            foreach (BusinessModel.PendingInternalTransfer pendingInternalTransfer in pendingInternalTransferList)
            {
                try
                {
                    internalTransferService.GeneratePendingInternalTransfer(pendingInternalTransfer);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    pendingInternalTransfer.Attempts += 1;

                    if (pendingInternalTransfer.Attempts >= _settings.Attempts)
                        pendingInternalTransfer.Status = PendingInternalTransferStatus.Error;

                    internalTransferService.Update(pendingInternalTransfer);
                }
            }
        }
    }
}
