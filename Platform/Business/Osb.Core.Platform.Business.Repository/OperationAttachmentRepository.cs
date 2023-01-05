using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class OperationAttachmentRepository : IOperationAttachmentRepository
    {
        private readonly IDbContext<OperationAttachment> _context;

        public OperationAttachmentRepository(IDbContext<OperationAttachment> context)
        {
            this._context = context;
        }

        public void Save(OperationAttachment operationAttachment, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramName"] = operationAttachment.Name,
                ["paramExtension"] = operationAttachment.Extension,
                ["paramOperationId"] = operationAttachment.OperationId,
                ["paramUserId"] = operationAttachment.CreationUserId
            };
            
            _context.ExecuteWithNoResult("InsertOperationAttachment", parameters, transactionScope);
        }
    }
}