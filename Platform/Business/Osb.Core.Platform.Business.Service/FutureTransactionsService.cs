using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Validators;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service
{
    public class FutureTransactionsService : IFutureTransactionsService
    {
        private readonly FutureTransactionsValidator _validator;
        private readonly FutureTransactionsMapper _mapper;
        private readonly IFutureTransactionsServiceFactory _futureTransactionsIntegrationServiceFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;

        public FutureTransactionsService(
            IFutureTransactionsServiceFactory futureTransactionsIntegrationServiceFactory,
            IAccountRepositoryFactory accountRepositoryFactory
        )
        {
            _futureTransactionsIntegrationServiceFactory = futureTransactionsIntegrationServiceFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _mapper = new FutureTransactionsMapper();
            _validator = new FutureTransactionsValidator();
        }

        public FindFutureTransactionsListResult FindFutureTransactionsList(FindFutureTransactionsListRequest findFutureTransactionsListRequest)
        {
            _validator.Validate(findFutureTransactionsListRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(findFutureTransactionsListRequest.AccountId);

            IntegrationRequest.FindFutureTransactionsListRequest integrationRequest = _mapper.Map(findFutureTransactionsListRequest, account);

            IntegrationService.IFutureTransactionsService futureTransactionsIntegrationService = _futureTransactionsIntegrationServiceFactory.Create();
            IntegrationResponse.FindFutureTransactionsListResponse FutureTransactionsListResponse = futureTransactionsIntegrationService.FindFutureTransactionsList(integrationRequest);

            FindFutureTransactionsListResult result = _mapper.Map(FutureTransactionsListResponse);

            return result;
        }

        // public FindFuturePaymentsListResult FindFuturePaymentsList(FindFuturePaymentsListRequest findFuturePaymentsListRequest)
        // {
        //     _validator.Validate(findFuturePaymentsListRequest);

        //     IAccountRepository accountRepository = _accountRepositoryFactory.Create();
        //     Account account = accountRepository.GetById(findFuturePaymentsListRequest.AccountId);

        //     IntegrationRequest.FindFuturePaymentsListRequest integrationRequest = _mapper.Map(findFuturePaymentsListRequest, account);

        //     IntegrationService.IFutureTransactionsService futureTransactionsIntegrationService = _futureTransactionsIntegrationServiceFactory.Create();
        //     IntegrationResponse.FindFuturePaymentsListResponse futurePaymentsListResponse = futureTransactionsIntegrationService.FindFuturePaymentsList(integrationRequest);

        //     FindFuturePaymentsListResult result = _mapper.Map(futurePaymentsListResponse);

        //     return result;
        // }

        public CancelFuturePaymentResult CancelFuturePayment(CancelFuturePaymentRequest cancelFuturePaymentRequest)
        {
            IntegrationService.IFutureTransactionsService cancelFuturePaymenService = _futureTransactionsIntegrationServiceFactory.Create();

            IntegrationRequest.CancelFuturePaymentRequest integrationRequest = _mapper.Map(cancelFuturePaymentRequest);
            IntegrationResponse.CancelFuturePaymentResponse cancelFuturePaymentResponse = cancelFuturePaymenService.CancelFuturePayment(integrationRequest);

            CancelFuturePaymentResult result = _mapper.Map(cancelFuturePaymentResponse);

            return result;
        }
    }
}