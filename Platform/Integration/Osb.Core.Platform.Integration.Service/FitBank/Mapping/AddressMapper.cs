using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class AddressMapper : Mapper
    {
        public ExternalRequest Map(FindAddressByZipCodeRequest findAddressByZipCodeRequest)
        {
            return new ExternalRequest
            {
                Url = findAddressByZipCodeRequest.Url,
                Headers = null,
                Body = new
                {
                    ZipCode = findAddressByZipCodeRequest.ZipCode
                }
            };
        }

        public FindAddressByZipCodeResponse Map(ExternalFindAddressByZipCodeResponse externalResponse)
        {
            return new FindAddressByZipCodeResponse
            {
                AddressLine = externalResponse.Address.AddressLine,
                ZipCode = externalResponse.Address.ZipCode,
                Neighborhood = externalResponse.Address.Neighborhood,
                CityCode = externalResponse.Address.CityCode,
                CityName = externalResponse.Address.CityName,
                State = externalResponse.Address.State
            };
        }
    }
}