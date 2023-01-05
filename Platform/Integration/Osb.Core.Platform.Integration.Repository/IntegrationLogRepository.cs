using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Repository.Interfaces;

namespace Osb.Core.Platform.Integration.Repository
{
    public class IntegrationLogRepository : IIntegrationLogRepository
    {
        private readonly IDbContext<IntegrationLog> _context;

        public IntegrationLogRepository(IDbContext<IntegrationLog> context)
        {
            _context = context;
        }
        public void InsertIntegrationLog(IntegrationLog integrationLog)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramBody"] = integrationLog.Body,
                ["paramUrl"] = integrationLog.Url,
                ["paramHeaders"] = integrationLog.Headers,
                ["paramStatusCode"] = integrationLog.StatusCode,
                ["paramResponse"] = integrationLog.Response,
                ["paramUserId"] = integrationLog.CreationUserId
            };

            _context.ExecuteWithNoResult("InsertIntegrationLog", parameters);
        }
    }
}