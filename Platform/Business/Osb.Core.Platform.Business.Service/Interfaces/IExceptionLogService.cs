using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IExceptionLogService
    {
        void SaveExceptionLog(string message, ExceptionType exceptionType);
    }
}

