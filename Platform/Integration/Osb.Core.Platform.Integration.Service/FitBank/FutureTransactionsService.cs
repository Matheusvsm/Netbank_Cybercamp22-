using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Common;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class FutureTransactionsService : IFutureTransactionsService
    {
        public readonly FutureTransactionsMapper _mapper;
        private readonly RequestHandler _requestHandler;
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public FutureTransactionsService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _mapper = new FutureTransactionsMapper();
            _requestHandler = new RequestHandler();
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public FindFutureTransactionsListResponse FindFutureTransactionsList(FindFutureTransactionsListRequest findFutureTransactionsListRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findFutureTransactionsListRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findFutureTransactionsListRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findFutureTransactionsListRequest.UserId);

            ExternalFindFutureTransactionsListResponse externalFindFutureTransactionsListResponse = _mapper.Map<ExternalFindFutureTransactionsListResponse>(externalResponse);
            IEnumerable<FutureTransaction> futureTransactions = _mapper.Map<IEnumerable<FutureTransaction>>(externalFindFutureTransactionsListResponse.Transactions);
            FindFutureTransactionsListResponse response = FindFutureTransactionsListResponse.Create(futureTransactions);

            return response;
        }

        // public FindFuturePaymentsListResponse FindFuturePaymentsList(FindFuturePaymentsListRequest findFuturePaymentsListRequest)
        // {
        //     CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
        //         findFuturePaymentsListRequest.AccountId,
        //         _companyAuthenticationRepositoryFactory,
        //         _settings.AesKey,
        //         _settings.AesIV
        //     );

        //     ExternalRequest externalRequest = _mapper.Map(findFuturePaymentsListRequest, companyAuthentication);
        //     ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

        //     IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory);

        //     ExternalFindFuturePaymentsListResponse externalFindFuturePaymentsListResponse = _mapper.Map<ExternalFindFuturePaymentsListResponse>(externalResponse);
        //     IEnumerable<FuturePayment> futurePayments = _mapper.Map<IEnumerable<FuturePayment>>(externalFindFuturePaymentsListResponse.Payments);
        //     FindFuturePaymentsListResponse response = FindFuturePaymentsListResponse.Create(futurePayments);

        //     return response;
        // }

        public CancelFuturePaymentResponse CancelFuturePayment(CancelFuturePaymentRequest cancelFuturePaymentRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                cancelFuturePaymentRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(cancelFuturePaymentRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, cancelFuturePaymentRequest.UserId);

            CancelFuturePaymentResponse cancelFuturePaymentResponse = _mapper.Map<CancelFuturePaymentResponse>(externalResponse);

            return cancelFuturePaymentResponse;
        }
    }
}