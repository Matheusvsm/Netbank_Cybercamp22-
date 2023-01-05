using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;


namespace Osb.Core.Api.Application.Mapping
{
    public class AddressMapper
    {
        public BusinessRequest.FindAddressByZipCodeRequest Map(FindAddressByZipCodeRequest findAddressByZipCodeRequest)
        {
            return new BusinessRequest.FindAddressByZipCodeRequest
            {
                ZipCode = Formatter.MaskFromZipCode(findAddressByZipCodeRequest.ZipCode)
            };
        }
    }
}