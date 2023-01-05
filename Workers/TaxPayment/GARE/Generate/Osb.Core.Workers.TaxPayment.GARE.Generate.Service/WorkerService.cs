using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using BusinessModel = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.TaxPayment.GARE.Generate
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
            IEnumerable<BusinessModel.GAREPayment> garePaymentList = taxPaymentService.FindGAREPaymentListByStatus(GAREPaymentStatus.Created);

            foreach (BusinessModel.GAREPayment garePayment in garePaymentList)
            {
                try
                {
                    taxPaymentService.GenerateGAREPayment(garePayment);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    garePayment.Attempts += 1;

                    if (garePayment.Attempts >= _settings.Attempts)
                        garePayment.Status = GAREPaymentStatus.Error;

                    taxPaymentService.UpdateGAREPayment(garePayment);
                }
            }
        }
    }
}