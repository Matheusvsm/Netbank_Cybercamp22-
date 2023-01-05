using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using BusinessEntity = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.Pix.RefundPixIn.Service
{
    public class WorkerService
    {
        private readonly IPixServiceFactory _pixtServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(
            IPixServiceFactory pixServiceFactory,
            IExceptionLogServiceFactory exceptionLogServiceFactory,
            Settings settings
        )
        {
            _pixtServiceFactory = pixServiceFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            IPixService pixService = _pixtServiceFactory.Create();
            IEnumerable<BusinessEntity.RefundPixIn> refundPixInList = pixService.FindRefundPixInListByStatus(RefundPixInStatus.Created);

            foreach(BusinessEntity.RefundPixIn refundPixIn in refundPixInList)
            {
                try
                {
                    pixService.GenerateRefundPixIn(refundPixIn);
                }
                catch(Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    if(++refundPixIn.Attempts == _settings.Attempts)
                        refundPixIn.Status = RefundPixInStatus.Error;
                        
                    pixService.Update(refundPixIn);
                }
            }
        }
    }
}
