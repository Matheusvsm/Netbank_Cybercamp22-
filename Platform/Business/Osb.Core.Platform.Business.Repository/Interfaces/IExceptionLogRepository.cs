using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IExceptionLogRepository
    {
        void Save(ExceptionLog exceptionLog);
    }
}