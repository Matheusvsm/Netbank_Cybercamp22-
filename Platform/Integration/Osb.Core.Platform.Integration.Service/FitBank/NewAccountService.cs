using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Service.Fitbank.Mapping;
using Osb.Core.Platform.Integration.Service.Fitbank.Interfaces;
using Osb.Core.Platform.Integration.Entity.Fitbank.Models.Response;
using Osb.Core.Platform.Integration.Entity.Fitbank.Models.Request;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.Fitbank
{
    public class NewAccountService : INewAccountService
    {
        public readonly NewAccountMapper _mapper = new NewAccountMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public NewAccountService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public NewAccountResponse NewAccount(NewAccountRequest newAccountRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByCompanyId(
                newAccountRequest.CompanyId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(newAccountRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, newAccountRequest.UserId);

            NewAccountResponse response = _mapper.Map<NewAccountResponse>(externalResponse);

            return response;
        }
    }
}