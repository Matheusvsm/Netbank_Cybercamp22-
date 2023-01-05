using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Request;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class DeviceMapper
    {
        public RegisterUserDeviceRequest Map(RegisterDeviceRequest registerDeviceRequest, object companyId)
        {
            return new RegisterUserDeviceRequest
            {
                UserId = registerDeviceRequest.UserId,
                AccountId = registerDeviceRequest.AccountId,
                Token = registerDeviceRequest.Token,
                CompanyId = (long)companyId
            };
        }
    }
}