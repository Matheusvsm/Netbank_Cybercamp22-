using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Repository
{
    public class OperationTagRepository : IOperationTagRepository
    {
        private readonly IDbContext<OperationTag> _context;

        public OperationTagRepository(IDbContext<OperationTag> context)
        {
            this._context = context;
        }

        public OperationTag Save(OperationTag operationTag, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramOperationId"] = operationTag.OperationId,
                ["paramTag"] = operationTag.Tag,
                ["paramUserId"] = operationTag.CreationUserId
            };

            return _context.ExecuteWithSingleResult("insertoperationtag", parameters, transactionScope);
        }

        public OperationTag GetById(long operationTagId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramOperationTagId"] = operationTagId
            };

            OperationTag operationTag = _context.ExecuteWithSingleResult("GetOperationTagById", parameters);

            return operationTag;
        }

        public IEnumerable<OperationTag> GetOperationTagsByOperationId(long OperationId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramOperationId"] = OperationId,
            };

            IEnumerable<OperationTag> operationTagsByOperationId = _context.ExecuteWithMultipleResults("GetOperationTagsByOperationId", parameters);

            return operationTagsByOperationId;
        }
    }
}