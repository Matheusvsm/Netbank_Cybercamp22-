using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IInternalTransferRepository
    {
        void Save(InternalTransfer internalTransfer, TransactionScope transactionScope = null);
        void Update(InternalTransfer internalTransfer);
        InternalTransfer GetById(long internalTransferId);
        InternalTransfer GetByExternalIdentifier(long externalIdentifier);
        IEnumerable<InternalTransfer> GetByStatus(InternalTransferStatus status, long? loadValue = null);

        void Save(PendingInternalTransfer pendingInternalTransfer, TransactionScope transactionScope = null);
        void Update(PendingInternalTransfer pendingInternalTransfer);
        IEnumerable<PendingInternalTransfer> GetListByStatus(PendingInternalTransferStatus status);
    }
}