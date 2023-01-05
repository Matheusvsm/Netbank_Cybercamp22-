using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class FutureTransactionsMapper : Mapper
    {
        public ExternalRequest Map(
            FindFutureTransactionsListRequest findFutureTransactionsListRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findFutureTransactionsListRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findFutureTransactionsListRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = findFutureTransactionsListRequest.TaxId,
                    Bank = findFutureTransactionsListRequest.Bank,
                    BankBranch = findFutureTransactionsListRequest.BankBranch,
                    BankAccount = findFutureTransactionsListRequest.BankAccount,
                    BankAccountDigit = findFutureTransactionsListRequest.BankAccountDigit,
                    FromDate = findFutureTransactionsListRequest.InitialDate,
                    ToDate = findFutureTransactionsListRequest.FinalDate,
                    OperationType = findFutureTransactionsListRequest.OperationType,
                    FutureTransactionType = findFutureTransactionsListRequest.FutureTransactionType,
                    Index = findFutureTransactionsListRequest.Index,
                    PageSize = findFutureTransactionsListRequest.PageSize
                }
            };
        }

        // public ExternalRequest Map(
        //     FindFuturePaymentsListRequest findFuturePaymentsListRequest,
        //     CompanyAuthentication companyAuthentication)
        // {
        //     Headers headers = HeadersMapper.Map(
        //         AuthorizationMapper.Map(companyAuthentication),
        //         findFuturePaymentsListRequest.Headers
        //     );

        //     return new ExternalRequest
        //     {
        //         Url = companyAuthentication.Url,
        //         Headers = headers,
        //         Body = new
        //         {
        //             Method = findFuturePaymentsListRequest.Method,
        //             BusinessUnitId = companyAuthentication.CompanyId,
        //             PartnerId = companyAuthentication.CompanyAuthenticationId,
        //             TaxNumber = findFuturePaymentsListRequest.TaxId,
        //             Bank = findFuturePaymentsListRequest.Bank,
        //             BankBranch = findFuturePaymentsListRequest.BankBranch,
        //             BankAccount = findFuturePaymentsListRequest.BankAccount,
        //             BankAccountDigit = findFuturePaymentsListRequest.BankAccountDigit,
        //             FromDate = findFuturePaymentsListRequest.InitialDate,
        //             ToDate = findFuturePaymentsListRequest.FinalDate,
        //             PaymentType = findFuturePaymentsListRequest.PaymentType
        //         }
        //     };
        // }

        public ExternalRequest Map(
        CancelFuturePaymentRequest cancelFuturePaymentRequest,
        CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                cancelFuturePaymentRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = cancelFuturePaymentRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    DocumentNumber = cancelFuturePaymentRequest.ExternalIdentifier
                }
            };
        }
    }
}