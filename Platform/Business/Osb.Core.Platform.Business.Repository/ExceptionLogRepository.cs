using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Repository
{
    public class ExceptionLogRepository : IExceptionLogRepository
    {
        private readonly IDbContext<ExceptionLog> _context;

        public ExceptionLogRepository(IDbContext<ExceptionLog> context)
        {
            this._context = context;
        }

        public void Save(ExceptionLog exceptionLog)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramMessage"] = exceptionLog.Message,
                ["paramExceptionType"] = exceptionLog.ExceptionType,
                ["paramUserId"] = exceptionLog.CreationUserId
            };

            _context.ExecuteWithNoResult("InsertExceptionLog", parameters);
        }

    }
}