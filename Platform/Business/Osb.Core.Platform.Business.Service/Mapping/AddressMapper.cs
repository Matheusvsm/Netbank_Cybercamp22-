using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class AddressMapper
    {
        public IntegrationRequest.FindAddressByZipCodeRequest Map(FindAddressByZipCodeRequest findAddressByZipCodeRequest, string url)
        {
            return new IntegrationRequest.FindAddressByZipCodeRequest
            {
                Url = url,
                ZipCode = findAddressByZipCodeRequest.ZipCode
            };
        }

        public FindAddressByZipCodeResult Map(FindAddressByZipCodeResponse findAddressByZipCodeResponse)
        {
            return new FindAddressByZipCodeResult
            {
                AddressLine = findAddressByZipCodeResponse.AddressLine,
                ZipCode = findAddressByZipCodeResponse.ZipCode,
                Neighborhood = findAddressByZipCodeResponse.Neighborhood,
                CityCode = findAddressByZipCodeResponse.CityCode,
                CityName = findAddressByZipCodeResponse.CityName,
                State = findAddressByZipCodeResponse.State
            };
        }
    }
}