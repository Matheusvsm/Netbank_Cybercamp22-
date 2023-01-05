using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Validators;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Service
{
    public class AddressService : IAddressService
    {
        private readonly AddressValidator _validator;
        private readonly AddressMapper _mapper;
        private readonly IAddressServiceFactory _accountIntegrationServiceFactory;
        private readonly Settings _settings;

        public AddressService(
            IAddressServiceFactory addressIntegrationServiceFactory,
            Settings settings
        )
        {
            _validator = new AddressValidator();
            _accountIntegrationServiceFactory = addressIntegrationServiceFactory;
            _settings = settings;
            _mapper = new AddressMapper();
        }
        public FindAddressByZipCodeResult FindAddresByZipCode(FindAddressByZipCodeRequest findAddressByZipCodeRequest)
        {
            _validator.Validate(findAddressByZipCodeRequest);

            IntegrationRequest.FindAddressByZipCodeRequest integrationRequest = _mapper.Map(findAddressByZipCodeRequest, _settings.UrlAddressApi);

            IntegrationService.IAddressService addressIntegrationService = _accountIntegrationServiceFactory.Create();
            IntegrationResponse.FindAddressByZipCodeResponse findAddressByZipCodeResponse = addressIntegrationService.FindAddressByZipCode(integrationRequest);
            
            FindAddressByZipCodeResult result = _mapper.Map(findAddressByZipCodeResponse);
            
            return result;
        }
    }
}