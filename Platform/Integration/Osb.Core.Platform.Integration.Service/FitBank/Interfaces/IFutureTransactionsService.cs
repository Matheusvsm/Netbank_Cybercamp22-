using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface IFutureTransactionsService
    {
        FindFutureTransactionsListResponse FindFutureTransactionsList(FindFutureTransactionsListRequest findFutureTransactionsListRequest);
        // FindFuturePaymentsListResponse FindFuturePaymentsList(FindFuturePaymentsListRequest findFuturePaymentsListRequest);
        CancelFuturePaymentResponse CancelFuturePayment(CancelFuturePaymentRequest cancelOperationRequest);
    }
}