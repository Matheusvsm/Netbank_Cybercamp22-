using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IDeviceRepository
    {
        Device SaveDevice(Device device);
        Device GetDeviceByUserIdAndCompanyId(long userId, long companyId);
        Device UpdateDeviceToken(string token, long userId);
        Device DeleteDevice(string token);
    }
}