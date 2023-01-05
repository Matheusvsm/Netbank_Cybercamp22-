using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Common;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class CardService : ICardService
    {
        public readonly CardMapper _mapper;
        private readonly RequestHandler _requestHandler;
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public CardService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings
        )
        {
            _mapper = new CardMapper();
            _requestHandler = new RequestHandler();
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public FindCardResponse FindCard(FindCardRequest findCardRequest)
        {
            CompanyAuthentication companyAuthentication = new CompanyAuthentication();

            if (!findCardRequest.AccountId.Equals(default(long)))
            {
                companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                    findCardRequest.AccountId,
                    _companyAuthenticationRepositoryFactory,
                    _settings.AesKey,
                    _settings.AesIV
                );
            }
            else
            {
                companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByCompanyId(
                  findCardRequest.CompanyId,
                  _companyAuthenticationRepositoryFactory,
                  _settings.AesKey,
                  _settings.AesIV
              );
            }

            ExternalRequest externalRequest = _mapper.Map(findCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findCardRequest.UserId);

            ExternalFindCardResponse externalFindCardResponse = _mapper.Map<ExternalFindCardResponse>(externalResponse);

            if (externalFindCardResponse.Data == null)
                throw new OsbIntegrationException(externalFindCardResponse.Message);

            FindCardResponse response = _mapper.Map<FindCardResponse>(externalFindCardResponse.Data);

            return response;
        }

        public FindCardListResponse FindCardList(FindCardListRequest findCardListRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findCardListRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findCardListRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findCardListRequest.UserId);

            ExternalFindCardListResponse externalFindCardListResponse = _mapper.Map<ExternalFindCardListResponse>(externalResponse);
            IEnumerable<Card> cards = _mapper.Map<IEnumerable<Card>>(externalFindCardListResponse.Cards);
            FindCardListResponse response = FindCardListResponse.Create(cards);

            return response;
        }

        public ActivateCardResponse Activate(ActivateCardRequest activateCardRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                activateCardRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(activateCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, activateCardRequest.UserId);

            ActivateCardResponse response = _mapper.Map<ActivateCardResponse>(externalResponse);

            return response;
        }

        public InactivateAndReissueCardResponse InactivateAndReissueCard(InactivateAndReissueCardRequest inactivateAndReissueCardRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                inactivateAndReissueCardRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(inactivateAndReissueCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, inactivateAndReissueCardRequest.UserId);

            InactivateAndReissueCardResponse response = _mapper.Map<InactivateAndReissueCardResponse>(externalResponse);

            return response;
        }

        public BlockCardResponse Block(BlockCardRequest blockCardRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                blockCardRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(blockCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, blockCardRequest.UserId);

            BlockCardResponse response = _mapper.Map<BlockCardResponse>(externalResponse);

            return response;
        }

        public UnblockCardResponse Unblock(UnblockCardRequest unblockCardRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                unblockCardRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(unblockCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, unblockCardRequest.UserId);

            UnblockCardResponse response = _mapper.Map<UnblockCardResponse>(externalResponse);

            return response;
        }

        public BindUnnamedCardResponse BindUnnamedCard(BindUnnamedCardRequest bindUnnamedCardRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                bindUnnamedCardRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(bindUnnamedCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, bindUnnamedCardRequest.UserId);

            BindUnnamedCardResponse response = _mapper.Map<BindUnnamedCardResponse>(externalResponse);

            return response;
        }

        public ChangePinCardResponse ChangePin(ChangePinCardRequest changePinCardRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                changePinCardRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(changePinCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, changePinCardRequest.UserId);

            ChangePinCardResponse response = _mapper.Map<ChangePinCardResponse>(externalResponse);

            return response;
        }

        public CancelCardResponse CancelCard(CancelCardRequest cancelCardRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
              cancelCardRequest.AccountId,
              _companyAuthenticationRepositoryFactory,
              _settings.AesKey,
              _settings.AesIV
          );

            ExternalRequest externalRequest = _mapper.Map(cancelCardRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            CancelCardResponse response = _mapper.Map<CancelCardResponse>(externalResponse);

            return response;
        }
    }
}