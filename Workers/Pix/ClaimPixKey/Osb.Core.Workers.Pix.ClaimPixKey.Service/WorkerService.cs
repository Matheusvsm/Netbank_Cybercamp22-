using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using BusinessEntity = Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Workers.Pix.ClaimPixKey.Service
{
    public class WorkerService
    {
        private readonly IPixServiceFactory _pixServiceFactory;
        private readonly IExceptionLogServiceFactory _exceptionLogServiceFactory;
        private readonly Settings _settings;

        public WorkerService(
            IPixServiceFactory pixServiceFactory,
            IExceptionLogServiceFactory exceptionLogServiceFactory,
            Settings settings
        )
        {
            _pixServiceFactory = pixServiceFactory;
            _exceptionLogServiceFactory = exceptionLogServiceFactory;
            _settings = settings;
        }

        public void Claim()
        {
            IPixService pixService = _pixServiceFactory.Create();
            IEnumerable<BusinessEntity.PixKey> pixKeyList = pixService.FindPixKeyListByStatus(PixKeyStatus.ErrorPortability);

            foreach (BusinessEntity.PixKey pixKey in pixKeyList)
            {
                try
                {
                    pixService.ClaimPixKey(pixKey);
                }
                catch (Exception ex)
                {
                    IExceptionLogService exceptionLogService = _exceptionLogServiceFactory.Create();
                    exceptionLogService.SaveExceptionLog(ex.Message, ExceptionType.OsbWorkerException);

                    if (++pixKey.Attempts == _settings.Attempts)
                        pixKey.Status = PixKeyStatus.Error;

                    pixService.UpdatePixKey(pixKey);
                }
            }
        }
    }
}
