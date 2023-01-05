using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Common;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class InternalTransferService : IInternalTransferService
    {
        private readonly InternalTransferMapper _mapper = new InternalTransferMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public InternalTransferService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public InternalTransferResponse InternalTransfer(InternalTransferRequest internalTransferRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                internalTransferRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(internalTransferRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, internalTransferRequest.UserId);

            InternalTransferResponse response = _mapper.Map<InternalTransferResponse>(externalResponse);
            return response;
        }

        public FindPendingInternalTransferResponse FindPendingInternalTransfer(FindPendingInternalTransferRequest findPendingInternalTransferRequest)
        {

            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByCompanyId
            (
                findPendingInternalTransferRequest.CompanyId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findPendingInternalTransferRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findPendingInternalTransferRequest.UserId);

            ExternalFindPendingInternalTransferResponse externalFindPendingInternalTransferResponse = _mapper.Map<ExternalFindPendingInternalTransferResponse>(externalResponse);

            if (!externalFindPendingInternalTransferResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindPendingInternalTransferResponse.Message);

            FindPendingInternalTransferResponse response = _mapper.Map(externalFindPendingInternalTransferResponse);

            return response;
        }

        public PendingInternalTransferResponse GeneratePendingInternalTransfer(PendingInternalTransferRequest pendingInternalTransferRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                pendingInternalTransferRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(pendingInternalTransferRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, pendingInternalTransferRequest.UserId);

            PendingInternalTransferResponse response = _mapper.Map<PendingInternalTransferResponse>(externalResponse.Data);

            return response;
        }
    }
}