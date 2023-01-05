using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Common;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class TaxPaymentService : ITaxPaymentService
    {
        private readonly TaxPaymentMapper _mapper = new TaxPaymentMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly Settings _settings;

        public TaxPaymentService(ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory, Settings settings)
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _settings = settings;
        }

        public FGTSPaymentResponse GenerateFGTSPayment(FGTSPaymentRequest fgtsPaymentRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                fgtsPaymentRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(fgtsPaymentRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            FGTSPaymentResponse response = _mapper.Map<FGTSPaymentResponse>(externalResponse);

            if (!response.ResponseStatus)
                throw new OsbIntegrationException(response.Message);

            return response;
        }

        public DARJPaymentResponse GeneratePaymentDARJ(DARJPaymentRequest darjPaymentRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                darjPaymentRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(darjPaymentRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            DARJPaymentResponse response = _mapper.Map<DARJPaymentResponse>(externalResponse);

            if (!response.ResponseStatus)
                throw new OsbIntegrationException(response.Message);

            return response;
        }

        public GAREPaymentResponse GenerateGAREPayment(GAREPaymentRequest garePaymentRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                garePaymentRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(garePaymentRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            GAREPaymentResponse response = _mapper.Map<GAREPaymentResponse>(externalResponse);

            if (!response.ResponseStatus)
                throw new OsbIntegrationException(response.Message);

            return response;
        }
    }
}