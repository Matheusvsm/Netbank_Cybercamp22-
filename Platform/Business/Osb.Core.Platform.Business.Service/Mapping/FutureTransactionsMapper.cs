using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class FutureTransactionsMapper
    {
        public IntegrationRequest.FindFutureTransactionsListRequest Map(FindFutureTransactionsListRequest findFutureTransactionsListRequest, Account account)
        {
            return new IntegrationRequest.FindFutureTransactionsListRequest
            {
                AccountId = findFutureTransactionsListRequest.AccountId,
                OperationType = findFutureTransactionsListRequest.OperationType,
                FutureTransactionType = findFutureTransactionsListRequest.FutureTransactionType,
                InitialDate = findFutureTransactionsListRequest.InitialDate,
                FinalDate = findFutureTransactionsListRequest.FinalDate,
                TaxId = account.TaxId,
                Bank = account.Bank,
                BankBranch = account.BankBranch,
                BankAccount = account.BankAccount,
                BankAccountDigit = account.BankAccountDigit,
                Index = findFutureTransactionsListRequest.Index,
                PageSize = findFutureTransactionsListRequest.PageSize,
                UserId = findFutureTransactionsListRequest.UserId
            };
        }

        // public IntegrationRequest.FindFuturePaymentsListRequest Map(FindFuturePaymentsListRequest findFuturePaymentsListRequest, Account account)
        // {
        //     return new IntegrationRequest.FindFuturePaymentsListRequest
        //     {
        //         AccountId = findFuturePaymentsListRequest.AccountId,
        //         PaymentType = findFuturePaymentsListRequest.PaymentType,
        //         InitialDate = findFuturePaymentsListRequest.InitialDate,
        //         FinalDate = findFuturePaymentsListRequest.FinalDate,
        //         TaxId = account.TaxId,
        //         Bank = account.Bank,
        //         BankBranch = account.BankBranch,
        //         BankAccount = account.BankAccount,
        //         BankAccountDigit = account.BankAccountDigit
        //     };
        // }


        public FindFutureTransactionsListResult Map(IntegrationResponse.FindFutureTransactionsListResponse findFutureTransactionsListResponse)
        {
            FindFutureTransactionsListResult transactionsListResult = new FindFutureTransactionsListResult();

            transactionsListResult.Transactions = new List<FutureTransaction>();

            foreach (FutureTransaction transaction in findFutureTransactionsListResponse.FutureTransactions)
            {
                if (transaction.Identifier != 0)
                    transactionsListResult.Transactions.Add(transaction);
            }

            return transactionsListResult;
        }

        // public FindFuturePaymentsListResult Map(IntegrationResponse.FindFuturePaymentsListResponse findFuturePaymentsListResponse)
        // {
        //     FindFuturePaymentsListResult paymentsListResult = new FindFuturePaymentsListResult();

        //     paymentsListResult.Payments = new List<FuturePayment>();

        //     foreach (FuturePayment payment in findFuturePaymentsListResponse.FuturePayments)
        //     {
        //         if (payment.Identifier != 0)
        //             paymentsListResult.Payments.Add(payment);
        //     }

        //     return paymentsListResult;
        // }

        public IntegrationRequest.CancelFuturePaymentRequest Map(CancelFuturePaymentRequest cancelFuturePaymentRequest)
        {
            Method method = cancelFuturePaymentRequest.OperationType switch
            {
                OperationType.InternalTransfer => Method.CancelInternalTransfer,
                OperationType.MoneyTransfer => Method.CancelMoneyTransfer,
                OperationType.BoletoPayment => Method.CancelBoletoOut,
                OperationType.GAREPayment => Method.CancelPaymentGare,
                OperationType.FGTSPayment => Method.CancelPaymentFgts,
                OperationType.DARJPayment => Method.CancelPaymentDARJ,
                OperationType.PendingInternalTransfer => Method.CancelTransferBySMS,
                _ => throw new ArgumentOutOfRangeException(nameof(cancelFuturePaymentRequest.OperationType), $"Not expected operation value: {cancelFuturePaymentRequest.OperationType}")
            };

            return new IntegrationRequest.CancelFuturePaymentRequest()
            {
                Method = Enum.GetName(method),
                AccountId = cancelFuturePaymentRequest.AccountId,
                ExternalIdentifier = cancelFuturePaymentRequest.ExternalIdentifier,
                UserId = cancelFuturePaymentRequest.UserId
            };
        }

        public CancelFuturePaymentResult Map(IntegrationResponse.CancelFuturePaymentResponse cancelFuturePaymentResponse)
        {
            return new CancelFuturePaymentResult()
            {
                Success = cancelFuturePaymentResponse.ResponseStatus,
                Message = cancelFuturePaymentResponse.Message
            };
        }


    }
}