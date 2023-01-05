using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class MoneyTransferService : IMoneyTransferService
    {
        private readonly MoneyTransferMapper _mapper = new MoneyTransferMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public MoneyTransferService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _mapper = new MoneyTransferMapper();
            _requestHandler = new RequestHandler();
            _settings = settings;
        }

        public MoneyTransferResponse MoneyTransfer(MoneyTransferRequest moneyTransferRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                moneyTransferRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(moneyTransferRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, moneyTransferRequest.UserId);

            MoneyTransferResponse response = _mapper.Map<MoneyTransferResponse>(externalResponse);

            return response;
        }

        public FindExpectedTransferDateResponse FindExpectedTransferDate(FindExpectedTransferDateRequest findExpectedTransferDateRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findExpectedTransferDateRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findExpectedTransferDateRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findExpectedTransferDateRequest.UserId);

            var externalFindExpectedTransferDateResponse = _mapper.Map<ExternalFindExpectedTransferDateResponse>(externalResponse);
            FindExpectedTransferDateResponse response = _mapper.Map(externalFindExpectedTransferDateResponse);

            return response;
        }
    }
}