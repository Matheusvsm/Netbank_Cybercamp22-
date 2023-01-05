using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class TagService : ITagService
    {
        private readonly TagMapper _mapper = new TagMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;
        private readonly Settings _settings;

        public TagService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            IIntegrationLogRepositoryFactory integrationLogRepositoryFactory,
            Settings settings)
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
            _settings = settings;
        }

        public FindSuggestionTagListResponse FindSuggestionTagList(FindSuggestionTagListRequest findSuggestionTagsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findSuggestionTagsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            try
            {
                ExternalRequest externalRequest = _mapper.Map(findSuggestionTagsRequest, companyAuthentication);
                ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

                IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findSuggestionTagsRequest.UserId);

                FindSuggestionTagListResponse response = _mapper.Map<FindSuggestionTagListResponse>(externalResponse);

                return response;

            }
            catch (Exception)
            {
                FindSuggestionTagListResponse response = _mapper.Map(new List<string>());
                return response;
            }
        }
    }
}