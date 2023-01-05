using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.TaxPayment.FGTS.Generate.Service
{
    public class WorkerService
    {
        private readonly ITaxPaymentServiceFactory _taxPaymentServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(ITaxPaymentServiceFactory taxPaymentServiceFactory, IExceptionLogServiceFactory exceptionLogServiceFactory, Settings settings)
        {
            _taxPaymentServiceFactory = taxPaymentServiceFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Generate()
        {
            ITaxPaymentService taxPaymentService = _taxPaymentServiceFactory.Create();
            IEnumerable<BusinessModel.FGTSPayment> FGTSPayments = taxPaymentService.FindFGTSPaymentListByStatus(FGTSPaymentStatus.Created);

            foreach (BusinessModel.FGTSPayment FGTSPayment in FGTSPayments)
            {
                try
                {
                    taxPaymentService.GenerateFGTSPayment(FGTSPayment);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    FGTSPayment.Attempts += 1;

                    if (FGTSPayment.Attempts >= _settings.Attempts)
                        FGTSPayment.Status = FGTSPaymentStatus.Error;

                    taxPaymentService.UpdateFGTSpayment(FGTSPayment);
                }
            }
        }
    }
}