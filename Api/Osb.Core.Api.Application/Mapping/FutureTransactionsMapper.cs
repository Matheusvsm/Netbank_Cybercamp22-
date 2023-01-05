using Osb.Core.Api.Application.Util;
using Osb.Core.Api.Application.Models.Request;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class FutureTransactionsMapper
    {
        public BusinessRequest.FindFutureTransactionsListRequest Map(FindFutureTransactionsListRequest findFutureTransactionsListRequest)
        {
            return new BusinessRequest.FindFutureTransactionsListRequest
            {
                AccountId = findFutureTransactionsListRequest.AccountId,
                UserId = findFutureTransactionsListRequest.UserId,
                OperationType = findFutureTransactionsListRequest.OperationType,
                FutureTransactionType = findFutureTransactionsListRequest.FutureTransactionType,
                InitialDate = findFutureTransactionsListRequest.InitialDate,
                FinalDate = findFutureTransactionsListRequest.FinalDate,
                Index = findFutureTransactionsListRequest.Index,
                PageSize = findFutureTransactionsListRequest.PageSize
            };
        }

        // public BusinessRequest.FindFuturePaymentsListRequest Map(FindFuturePaymentsListRequest findFuturePaymentsListRequest)
        // {
        //     return new BusinessRequest.FindFuturePaymentsListRequest
        //     {
        //         AccountId = findFuturePaymentsListRequest.AccountId,
        //         UserId = findFuturePaymentsListRequest.UserId,
        //         PaymentType = findFuturePaymentsListRequest.PaymentType,
        //         InitialDate = findFuturePaymentsListRequest.InitialDate,
        //         FinalDate = findFuturePaymentsListRequest.FinalDate
        //     };
        // }

        public BusinessRequest.CancelFuturePaymentRequest Map(CancelFuturePaymentRequest cancelOperationRequest)
        {
            return new BusinessRequest.CancelFuturePaymentRequest()
            {
                UserId = cancelOperationRequest.UserId,
                AccountId = cancelOperationRequest.AccountId,
                OperationType = cancelOperationRequest.OperationType,
                ExternalIdentifier = cancelOperationRequest.ExternalIdentifier
            };
        }
    }
}