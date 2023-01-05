using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Common;
using System.Linq;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class PixService : IPixService
    {
        public readonly PixMapper _mapper;
        private readonly RequestHandler _requestHandler;
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public PixService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _mapper = new PixMapper();
            _requestHandler = new RequestHandler();
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public CreatePixKeyResponse CreatePixKey(CreatePixKeyRequest CreatePixKeyRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                CreatePixKeyRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(CreatePixKeyRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, CreatePixKeyRequest.UserId);

            CreatePixKeyResponse response = _mapper.Map<CreatePixKeyResponse>(externalResponse);

            return response;
        }

        public ConfirmPixKeyHoldResponse ConfirmPixKeyHold(ConfirmPixKeyHoldRequest confirmPixKeyHoldRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                confirmPixKeyHoldRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(confirmPixKeyHoldRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, confirmPixKeyHoldRequest.UserId);
            ConfirmPixKeyHoldResponse response = _mapper.Map<ConfirmPixKeyHoldResponse>(externalResponse);

            return response;
        }

        public ResendPixKeyTokenResponse ResendPixKeyToken(ResendPixKeyTokenRequest resendPixKeyTokenRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                resendPixKeyTokenRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(resendPixKeyTokenRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, resendPixKeyTokenRequest.UserId);
            ResendPixKeyTokenResponse response = _mapper.Map<ResendPixKeyTokenResponse>(externalResponse);

            return response;
        }

        public CancelPixKeyResponse CancelPixKey(CancelPixKeyRequest cancelPixKeyRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                cancelPixKeyRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(cancelPixKeyRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, cancelPixKeyRequest.UserId);

            CancelPixKeyResponse response = _mapper.Map<CancelPixKeyResponse>(externalResponse);

            if (!response.ResponseStatus)
                throw new OsbIntegrationException(response.Message);

            return response;
        }

        public RefundPixInResponse GenerateRefundPixIn(RefundPixInRequest refundPixInRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                refundPixInRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(refundPixInRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, refundPixInRequest.UserId);

            RefundPixInResponse response = _mapper.Map<RefundPixInResponse>(externalResponse);

            if (!response.ResponseStatus)
                throw new OsbIntegrationException(response.Message);

            return response;
        }

        public ExternalFindInfosPixKeyResponse FindInfosPixKey(FindInfosPixKeyRequest findInfosPixKeyRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findInfosPixKeyRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findInfosPixKeyRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findInfosPixKeyRequest.UserId);

            ExternalFindInfosPixKeyResponse externalFindInfosPixKeyResponse = _mapper.Map<ExternalFindInfosPixKeyResponse>(externalResponse);

            if (!externalFindInfosPixKeyResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindInfosPixKeyResponse.Message);

            return externalFindInfosPixKeyResponse;
        }

        public FindPixKeyListResponse FindPixKeyList(FindPixKeyListRequest findPixKeyListRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findPixKeyListRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findPixKeyListRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findPixKeyListRequest.UserId);

            try
            {
                FindPixKeyListResponse response = _mapper.Map<FindPixKeyListResponse>(externalResponse);

                return response;
            }
            catch
            {
                return new FindPixKeyListResponse
                {
                    PixKeys = Enumerable.Empty<PixKey>()
                };
            }
        }

        public GeneratePixOutResponse GeneratePixOut(GeneratePixOutRequest generatePixOutRequest)
        {

            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                generatePixOutRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(generatePixOutRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, generatePixOutRequest.UserId);
            GeneratePixOutResponse response = _mapper.Map<GeneratePixOutResponse>(externalResponse);

            return response;

        }

        public GenerateStaticPixQRCodeResponse GenerateStaticPixQRCode(GenerateStaticPixQRCodeRequest generateStaticPixQRCodeRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                generateStaticPixQRCodeRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(generateStaticPixQRCodeRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, generateStaticPixQRCodeRequest.UserId);

            GenerateStaticPixQRCodeResponse response = _mapper.Map<GenerateStaticPixQRCodeResponse>(externalResponse);

            return response;
        }

        public GenerateDynamicPixQrCodeResponse GenerateDynamicPixQrCode(GenerateDynamicPixQrCodeRequest generateDynamicPixQrCodeRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                generateDynamicPixQrCodeRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(generateDynamicPixQrCodeRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, generateDynamicPixQrCodeRequest.UserId);
            GenerateDynamicPixQrCodeResponse response = _mapper.Map<GenerateDynamicPixQrCodeResponse>(externalResponse);

            return response;
        }

        public FindPixQRCodeResponse FindPixQRCode(FindPixQRCodeRequest findPixQRCodeRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findPixQRCodeRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findPixQRCodeRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findPixQRCodeRequest.UserId);

            FindPixQRCodeResponse response = _mapper.Map<FindPixQRCodeResponse>(externalResponse);

            return response;
        }

        public FindInfoPixQRCodeResponse FindInfoPixQRCode(FindInfoPixQRCodeRequest findInfoPixQRCodeRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findInfoPixQRCodeRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findInfoPixQRCodeRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findInfoPixQRCodeRequest.UserId);

            FindInfoPixQRCodeResponse response = _mapper.Map<FindInfoPixQRCodeResponse>(externalResponse);

            if (!response.ResponseStatus)
                throw new OsbIntegrationException(response.Message);

            return response;
        }

        public ClaimPixKeyResponse ClaimPixKey(ClaimPixKeyRequest claimPixKeyRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                claimPixKeyRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(claimPixKeyRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, claimPixKeyRequest.UserId);

            ClaimPixKeyResponse response = _mapper.Map<ClaimPixKeyResponse>(externalResponse);

            return response;
        }
    }
}