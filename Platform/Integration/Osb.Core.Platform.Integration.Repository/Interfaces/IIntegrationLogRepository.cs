using Osb.Core.Platform.Integration.Entity.Models;

namespace Osb.Core.Platform.Integration.Repository.Interfaces
{
    public interface IIntegrationLogRepository
    {
        void InsertIntegrationLog(IntegrationLog integrationLog);
    }
}