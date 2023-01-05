using System.Collections.Generic;
using Osb.Core.Webhook.Entity;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;


namespace Osb.Core.Webhook.Repository
{
    public class OutputRepository : IOutputRepository
    {
        private readonly IDbContext<Output> _context;

        public OutputRepository(IDbContext<Output> context)
        {
            _context = context;
        }

        public void InsertOutputLog(Output output, long? userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramInputLogId"] = output.InputLogId,
                ["paramResponse"] = output.Response,
                ["paramUserId"] = userId,
                ["paramStatusCode"] = output.StatusCode
            };

            _context.ExecuteWithNoResult("InsertOutputLog", parameters);
        }
    }
}