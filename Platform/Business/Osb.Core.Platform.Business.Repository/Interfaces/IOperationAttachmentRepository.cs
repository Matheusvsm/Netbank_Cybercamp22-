using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IOperationAttachmentRepository
    {
        void Save(OperationAttachment operationAttachment, TransactionScope transactionScope = null);
    }
}