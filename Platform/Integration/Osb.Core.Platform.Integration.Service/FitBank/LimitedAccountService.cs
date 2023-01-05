using Osb.Core.Platform.Integration.Service.Fitbank.Interfaces;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Fitbank.Mapping;

namespace Osb.Core.Platform.Integration.Service.Fitbank
{
    public class LimitedAccountService : ILimitedAccountService
    {
        private readonly LimitedAccountMapper _mapper = new LimitedAccountMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;
        public LimitedAccountService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }
        public LimitedAccountResponse LimitedAccount(LimitedAccountRequest limitedAccountRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByCompanyId(
                limitedAccountRequest.CompanyId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(limitedAccountRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, limitedAccountRequest.UserId);

            LimitedAccountResponse response = _mapper.Map<LimitedAccountResponse>(externalResponse);
            return response;
        }
    }
}