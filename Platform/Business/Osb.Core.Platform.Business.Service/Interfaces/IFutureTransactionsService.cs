using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IFutureTransactionsService
    {
        FindFutureTransactionsListResult FindFutureTransactionsList(FindFutureTransactionsListRequest findFutureTransactionsListRequest);
        // FindFuturePaymentsListResult FindFuturePaymentsList(FindFuturePaymentsListRequest findFuturePaymentsListRequest);
        CancelFuturePaymentResult CancelFuturePayment(CancelFuturePaymentRequest cancelFuturePaymentRequest);
    }
}