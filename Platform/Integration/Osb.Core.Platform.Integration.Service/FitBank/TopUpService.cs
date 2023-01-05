using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Common;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Util;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class TopUpService : ITopUpService
    {
        private readonly TopUpMapper _mapper = new TopUpMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public TopUpService(
           ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
           IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
           Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public FindTopUpProductListResponse FindTopUpProductList(FindTopUpProductListRequest findTopUpProductsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findTopUpProductsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(companyAuthentication, findTopUpProductsRequest);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findTopUpProductsRequest.UserId);

            FindTopUpProductListResponse response = _mapper.Map<FindTopUpProductListResponse>(externalResponse);

            return response;
        }

        public GenerateTopUpResponse GenerateTopUp(GenerateTopUpRequest topUpRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                topUpRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(topUpRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, topUpRequest.UserId);

            GenerateTopUpResponse response = _mapper.Map<GenerateTopUpResponse>(externalResponse);
            return response;
        }

        public TopUpAuthorizeResponse TopUpAuthorize(TopUpAuthorizeRequest topUpAuthorizeRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                topUpAuthorizeRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(topUpAuthorizeRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, topUpAuthorizeRequest.UserId);

            TopUpAuthorizeResponse response = _mapper.Map<TopUpAuthorizeResponse>(externalResponse);
            return response;
        }

        public FindTopUpProductListByPhoneNumberResponse FindTopUpProductListByPhoneNumber(FindTopUpProductListByPhoneNumberRequest findTopUpByPhoneNumberRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findTopUpByPhoneNumberRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findTopUpByPhoneNumberRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findTopUpByPhoneNumberRequest.UserId);

            FindTopUpProductListByPhoneNumberResponse response = _mapper.Map<FindTopUpProductListByPhoneNumberResponse>(externalResponse);

            return response;
        }
    }
}