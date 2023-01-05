using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Business.Service
{
    public class BankService : IBankService
    {
        private readonly BankValidator _validator;
        private readonly BankMapper _mapper;
        private readonly IBankServiceFactory _bankIntegrationServiceFactory;

        public BankService(
            IBankServiceFactory BankIntegrationServiceFactory
        )
        {
            _bankIntegrationServiceFactory = BankIntegrationServiceFactory;
            _mapper = new BankMapper();
            _validator = new BankValidator();
        }

        public FindBanksResult FindBanks(FindBanksRequest findBanksRequest)
        {
            _validator.Validate(findBanksRequest);

            IntegrationRequest.FindBanksRequest integrationRequest = _mapper.Map(
               findBanksRequest
            );
            IntegrationService.IBankService bankIntegrationService = _bankIntegrationServiceFactory.Create();
            IntegrationResponse.FindBanksResponse findBanksResponse = bankIntegrationService.FindBanks(integrationRequest);

            FindBanksResult result = _mapper.Map(findBanksResponse);
            return result;
        }

    }
}
