using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service
{
    public class ExceptionLogService : IExceptionLogService
    {
        private readonly IExceptionLogRepositoryFactory _exceptionLogRepositoryFactory;
        private readonly Settings _settings;

        public ExceptionLogService
        (
            IExceptionLogRepositoryFactory exceptionLogRepositoryFactory,
            Settings settings
        )
        {
            _exceptionLogRepositoryFactory = exceptionLogRepositoryFactory;
            _settings = settings;
        }

        public void SaveExceptionLog(string message, ExceptionType exceptionType)
        {
            IExceptionLogRepository exceptionLogRepository = _exceptionLogRepositoryFactory.Create();

            ExceptionLog exceptionLog = ExceptionLog.Create(message, exceptionType, _settings.UserDefault);

            exceptionLogRepository.Save(exceptionLog);
        }
    }
}
