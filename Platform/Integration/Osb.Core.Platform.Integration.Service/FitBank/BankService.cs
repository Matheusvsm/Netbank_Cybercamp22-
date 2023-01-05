using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class BankService : IBankService
    {
        public readonly BankMapper _mapper;
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly RequestHandler _requestHandler;
        private readonly Settings _settings;

        public BankService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _mapper = new BankMapper();
            _requestHandler = new RequestHandler();
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public FindBanksResponse FindBanks(FindBanksRequest findBanksRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBanksRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBanksRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findBanksRequest.UserId);

            ExternalFindBanksResponse externalFindBanksResponse = _mapper.Map<ExternalFindBanksResponse>(externalResponse);
            IEnumerable<Bank> banks = _mapper.Map<IEnumerable<Bank>>(externalFindBanksResponse.Banks);
            FindBanksResponse response = FindBanksResponse.Create(banks);
            return response;
        }
    }
}