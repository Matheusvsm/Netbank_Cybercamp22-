using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IInternalTransferService
    {
        OperationResult Save(InternalTransferRequest internalTransferRequest);
        void GenerateInternalTransfer(InternalTransfer internalTransfer);
        void Update(InternalTransfer internalTransfer);
        void UpdateStatus(UpdateInternalTransferRequest updateInternalTransferRequest);
        IEnumerable<InternalTransfer> FindInternalTransferListByStatus(InternalTransferStatus status);
        FindPendingInternalTransferResult FindPendingInternalTransfer(FindPendingInternalTransferRequest findPendingInternalTransferRequest);

        OperationResult Save(PendingInternalTransferRequest pendingInternalTransferRequest);
        void GeneratePendingInternalTransfer(PendingInternalTransfer pendingInternalTransfer);
        IEnumerable<PendingInternalTransfer> FindPendingInternalTransferListByStatus(PendingInternalTransferStatus status);
        void Update(PendingInternalTransfer pendingInternalTransfer);
    }
}