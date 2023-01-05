using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using BusinessEntity = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.TaxPayment.DARJ.Generate.Service
{
    public class WorkerService
    {
        private readonly ITaxPaymentServiceFactory _taxPaymentServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(
            ITaxPaymentServiceFactory taxPaymentServiceFactory,
            IExceptionLogServiceFactory exceptionLogServiceFactory,
            Settings settings
        )
        {
            _taxPaymentServiceFactory = taxPaymentServiceFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            ITaxPaymentService taxPaymentService = _taxPaymentServiceFactory.Create();
            IEnumerable<BusinessEntity.DARJPayment> darjPayments = taxPaymentService.FindDARJPaymentByStatus(DARJPaymentStatus.Created);

            foreach (BusinessEntity.DARJPayment darjPaymentToProcess in darjPayments)
            {
                try
                {
                    taxPaymentService.GenerateDARJPayment(darjPaymentToProcess);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    darjPaymentToProcess.Attempts += 1;

                    if (darjPaymentToProcess.Attempts >= _settings.Attempts)
                        darjPaymentToProcess.Status = DARJPaymentStatus.Error;

                    taxPaymentService.UpdateDARJPayment(darjPaymentToProcess);
                }
            }
        }
    }
}
