using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface IInternalTransferService
    {
        InternalTransferResponse InternalTransfer(InternalTransferRequest internalTransferRequest);
        FindPendingInternalTransferResponse FindPendingInternalTransfer(FindPendingInternalTransferRequest integrationRequest);
        PendingInternalTransferResponse GeneratePendingInternalTransfer(PendingInternalTransferRequest pendingInternalTransferRequest);
    }
}