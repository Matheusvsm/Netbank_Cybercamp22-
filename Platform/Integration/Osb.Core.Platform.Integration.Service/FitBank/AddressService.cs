using Osb.Core.Platform.Integration.Common;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Util;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class AddressService : IAddressService
    {
        private readonly AddressMapper _mapper = new AddressMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly IIntegrationLogRepositoryFactory _integrationLogRepositoryFactory;

        public AddressService(IIntegrationLogRepositoryFactory integrationLogRepositoryFactory)
        {
            _integrationLogRepositoryFactory = integrationLogRepositoryFactory;
        }

        public FindAddressByZipCodeResponse FindAddressByZipCode(FindAddressByZipCodeRequest findAddressByZipCodeRequest)
        {
            ExternalRequest externalRequest = _mapper.Map(findAddressByZipCodeRequest);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            IntegrationLogUtil.SaveLog(externalRequest, externalResponse, _integrationLogRepositoryFactory, findAddressByZipCodeRequest.UserId);

            ExternalFindAddressByZipCodeResponse externalFindAddressByZipCodeResponse = _mapper.Map<ExternalFindAddressByZipCodeResponse>(externalResponse);

            if (!externalFindAddressByZipCodeResponse.ResponseStatus)
                throw new OsbIntegrationException(externalFindAddressByZipCodeResponse.Message);

            FindAddressByZipCodeResponse response = _mapper.Map(externalFindAddressByZipCodeResponse);

            return response;
        }
    }
}