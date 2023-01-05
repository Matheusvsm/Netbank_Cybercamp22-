using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Business.Service
{
    public class TagService : Interfaces.ITagService
    {
        private readonly TagMapper _mapper;
        private readonly TagValidator _validator;

        private readonly ITagServiceFactory _suggestionTagIntegrationServiceFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;

        public TagService(
            ITagServiceFactory suggestionTagsIntegrationServiceFactory,
            IAccountRepositoryFactory accountRepositoryFactory)
        {
            _mapper = new TagMapper();
            _validator = new TagValidator();
            _suggestionTagIntegrationServiceFactory = suggestionTagsIntegrationServiceFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
        }

        public FindSuggestionTagListResult FindSuggestionTagList(FindSuggestionTagListRequest findSuggestionTagListRequest)
        {
            _validator.Validate(findSuggestionTagListRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(findSuggestionTagListRequest.AccountId);

            IntegrationRequest.FindSuggestionTagListRequest integrationRequest = _mapper.Map(findSuggestionTagListRequest, account);

            IntegrationService.ITagService suggestionTagsIntegrationService = _suggestionTagIntegrationServiceFactory.Create();
            FindSuggestionTagListResponse findSuggestionTagsResponse = suggestionTagsIntegrationService.FindSuggestionTagList(integrationRequest);

            FindSuggestionTagListResult result = _mapper.Map(findSuggestionTagsResponse);

            return result;
        }

    }
}