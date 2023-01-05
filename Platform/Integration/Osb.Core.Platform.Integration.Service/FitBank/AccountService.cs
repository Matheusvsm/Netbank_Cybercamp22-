using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Common;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class AccountService : IAccountService
    {
        public readonly AccountMapper _mapper = new AccountMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public AccountService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public FindAccountBalanceResponse FindAccountBalance(FindAccountBalanceRequest findAccountBalanceRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findAccountBalanceRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findAccountBalanceRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findAccountBalanceRequest.UserId);

            // FindAccountBalanceResponse response = _mapper.Map<FindAccountBalanceResponse>(externalResponse);
            FindAccountBalanceResponse response = new FindAccountBalanceResponse();
            response.Balance = 1000.0M;

            return response;
        }

        public FindBankStatementResponse FindBankStatement(FindBankStatementRequest findBankStatementRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBankStatementRequest.UserId);

            ExternalFindBankStatementResponse externalFindBankStatementResponse = _mapper.Map<ExternalFindBankStatementResponse>(externalResponse);

            IEnumerable<Transaction> transactions = _mapper.Map<IEnumerable<Transaction>>(externalFindBankStatementResponse.Transactions);

            FindBankStatementResponse response = FindBankStatementResponse.Create(transactions);

            return response;
        }

        public FindMoneyTransferDetailsResponse FindMoneyTransferDetails(FindBankStatementDetailsRequest findtBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findtBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findtBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findtBankStatementDetailsRequest.UserId);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);

            if (!externalFindBankStatementDetailsResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindBankStatementDetailsResponse.Message);

            FindMoneyTransferDetailsResponse response = _mapper.Map<FindMoneyTransferDetailsResponse>(externalFindBankStatementDetailsResponse.MoneyTransfer);

            return response;
        }

        public FindInternalTransferDetailsResponse FindInternalTransferDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBankStatementDetailsRequest.UserId);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);

            if (!externalFindBankStatementDetailsResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindBankStatementDetailsResponse.Message);

            FindInternalTransferDetailsResponse response = _mapper.Map<FindInternalTransferDetailsResponse>(externalFindBankStatementDetailsResponse.InternalTransfer);

            return response;
        }

        public FindBoletoPaymentDetailsResponse FindBoletoPaymentDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBankStatementDetailsRequest.UserId);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);

            if (!externalFindBankStatementDetailsResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindBankStatementDetailsResponse.Message);

            FindBoletoPaymentDetailsResponse response = _mapper.Map<FindBoletoPaymentDetailsResponse>(externalFindBankStatementDetailsResponse.BoletoPayment);

            return response;
        }
        public FindGAREPaymentDetailsResponse FindGAREPaymentDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBankStatementDetailsRequest.UserId);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);

            if (!externalFindBankStatementDetailsResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindBankStatementDetailsResponse.Message);

            FindGAREPaymentDetailsResponse response = _mapper.Map<FindGAREPaymentDetailsResponse>(externalFindBankStatementDetailsResponse.GAREPayment);

            return response;
        }

        public FindFGTSPaymentDetailsResponse FindFGTSPaymentDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBankStatementDetailsRequest.UserId);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);

            if (!externalFindBankStatementDetailsResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindBankStatementDetailsResponse.Message);

            FindFGTSPaymentDetailsResponse response = _mapper.Map<FindFGTSPaymentDetailsResponse>(externalFindBankStatementDetailsResponse.FGTSPayment);

            return response;
        }

        public FindDARJPaymentDetailsResponse FindDARJPaymentDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBankStatementDetailsRequest.UserId);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);

            if (!externalFindBankStatementDetailsResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindBankStatementDetailsResponse.Message);

            FindDARJPaymentDetailsResponse response = _mapper.Map<FindDARJPaymentDetailsResponse>(externalFindBankStatementDetailsResponse.DARJPayment);

            return response;
        }

        public FindTopUpDetailsResponse FindTopUpDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBankStatementDetailsRequest.UserId);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);

            if (!externalFindBankStatementDetailsResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindBankStatementDetailsResponse.Message);

            FindTopUpDetailsResponse response = _mapper.Map<FindTopUpDetailsResponse>(externalFindBankStatementDetailsResponse.TopUp);

            return response;
        }

        public FindBankStatementMonthlySummaryResponse FindBankStatementMonthlySummary(FindBankStatementMonthlySummaryRequest findBankStatementMonthlySummaryRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementMonthlySummaryRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementMonthlySummaryRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBankStatementMonthlySummaryRequest.UserId);

            ExternalFindBankStatementMonthlySummaryResponse externalFindBankStatementMonthlySummaryResponse = _mapper.Map<ExternalFindBankStatementMonthlySummaryResponse>(externalResponse);
            FindBankStatementMonthlySummaryResponse response = _mapper.Map(externalFindBankStatementMonthlySummaryResponse);
            return response;
        }

        public ChangeAccountOperationLimitResponse ChangeAccountOperationLimit(ChangeAccountOperationLimitRequest changeAccountOperationLimitRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                changeAccountOperationLimitRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(changeAccountOperationLimitRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, changeAccountOperationLimitRequest.UserId);

            ChangeAccountOperationLimitResponse response = _mapper.Map<ChangeAccountOperationLimitResponse>(externalResponse);

            return response;
        }

        public FindAccountOperationLimitResponse FindAccountOperationLimit(FindAccountOperationLimitRequest findAccountOperationLimitRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findAccountOperationLimitRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findAccountOperationLimitRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findAccountOperationLimitRequest.UserId);

            FindAccountOperationLimitResponse response = _mapper.Map<FindAccountOperationLimitResponse>(externalResponse);
            return response;
        }

        public FindAccountOperationLimitListResponse FindAccountOperationLimitList(FindAccountOperationLimitListRequest findAccountOperationLimitListRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findAccountOperationLimitListRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findAccountOperationLimitListRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findAccountOperationLimitListRequest.UserId);

            FindAccountOperationLimitListResponse response = _mapper.Map<FindAccountOperationLimitListResponse>(externalResponse);
            return response;
        }

        public FindPixDetailsResponse FindPixTransferDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBankStatementDetailsRequest.UserId);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);

            if (!externalFindBankStatementDetailsResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindBankStatementDetailsResponse.Message);

            return externalFindBankStatementDetailsResponse.PixTransfer;
        }
    }
}