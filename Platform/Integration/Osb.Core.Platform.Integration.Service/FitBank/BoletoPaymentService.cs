using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Common;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class BoletoPaymentService : IBoletoPaymentService
    {
        public readonly BoletoPaymentMapper _mapper = new BoletoPaymentMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public BoletoPaymentService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public BoletoPaymentResponse GenerateBoletoPayment(BoletoPaymentRequest boletoPaymentRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                boletoPaymentRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(boletoPaymentRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, boletoPaymentRequest.UserId);

            ExternalBoletoPaymentInfosResponse externalBoletoPaymentInfosResponse = _mapper.Map<ExternalBoletoPaymentInfosResponse>(externalResponse);

            if (!externalBoletoPaymentInfosResponse.ResponseStatus)
                throw new OsbIntegrationException(externalBoletoPaymentInfosResponse.Message);

            BoletoPaymentResponse response = _mapper.Map<BoletoPaymentResponse>(externalResponse);

            return response;
        }
        public FindInfosPaymentCIPByBarcodeResponse FindInfosPaymentCIPByBarcode(FindInfosPaymentCIPByBarcodeRequest findInfosPaymentCIPByBarcodeRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findInfosPaymentCIPByBarcodeRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findInfosPaymentCIPByBarcodeRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findInfosPaymentCIPByBarcodeRequest.UserId);

            ExternalBoletoPaymentInfosResponse externalBoletoPaymentInfosResponse = _mapper.Map<ExternalBoletoPaymentInfosResponse>(externalResponse);

            if (!externalBoletoPaymentInfosResponse.ResponseStatus)
                throw new OsbIntegrationException(externalBoletoPaymentInfosResponse.Message);

            FindInfosPaymentCIPByBarcodeResponse response = _mapper.Map<FindInfosPaymentCIPByBarcodeResponse>(externalBoletoPaymentInfosResponse.Data);

            return response;
        }

        public FindInfosPaymentByBarcodeReponse FindInfosPaymentByBarcode(FindInfosPaymentByBarcodeRequest findInfosPaymentByBarcodeRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findInfosPaymentByBarcodeRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findInfosPaymentByBarcodeRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findInfosPaymentByBarcodeRequest.UserId);

            ExternalBoletoPaymentInfosResponse externalBoletoPaymentInfosResponse = _mapper.Map<ExternalBoletoPaymentInfosResponse>(externalResponse);

            if (!externalBoletoPaymentInfosResponse.ResponseStatus)
                throw new OsbIntegrationException(externalBoletoPaymentInfosResponse.Message);

            FindInfosPaymentByBarcodeReponse response = _mapper.Map<FindInfosPaymentByBarcodeReponse>(externalBoletoPaymentInfosResponse.Data);

            return response;
        }

        public VerifyBoletoCanBePaidResponse VerifyBoletoCanBePaid(VerifyBoletoCanBePaidRequest verifyBoletoCanBePaidRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                verifyBoletoCanBePaidRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(verifyBoletoCanBePaidRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, verifyBoletoCanBePaidRequest.UserId);

            VerifyBoletoCanBePaidResponse response = _mapper.Map<VerifyBoletoCanBePaidResponse>(externalResponse);

            return response;
        }

        public FindExpectedBoletoPaymentDateResponse FindExpectedBoletoPaymentDate(FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findExpectedBoletoPaymentDateRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findExpectedBoletoPaymentDateRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findExpectedBoletoPaymentDateRequest.UserId);

            var findExpectedBoletoPaymentDateResponse = _mapper.Map<ExternalFindExpectedBoletoPaymentDateResponse>(externalResponse);

            FindExpectedBoletoPaymentDateResponse response = _mapper.Map(findExpectedBoletoPaymentDateResponse);

            return response;
        }
    }
}