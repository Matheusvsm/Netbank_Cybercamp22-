using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IDbContext<Device> _context;

        public DeviceRepository(IDbContext<Device> context)
        {
            _context = context;
        }

        public Device SaveDevice(Device device)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramToken"] = device.Token,
                ["paramUserId"] = device.UserId,
                ["paramCompanyId"] = device.CompanyId
            };

            Device deviceResult = _context.ExecuteWithSingleResult("InsertDevice", parameters);

            return deviceResult;
        }

        public Device GetDeviceByUserIdAndCompanyId(long userId, long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId,
                ["paramCompanyId"] = companyId
            };

            Device device = _context.ExecuteWithSingleResult("GetDeviceByUserIdAndCompanyId", parameters);

            return device;
        }

        public Device UpdateDeviceToken(string token, long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramToken"] = token,
                ["paramUserId"] = userId
            };

            Device deviceResult = _context.ExecuteWithSingleResult("UpdateDeviceTokenByUserId", parameters);

            return deviceResult;
        }

        public Device DeleteDevice(string token)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramToken"] = token,
            };

            Device deviceResult = _context.ExecuteWithSingleResult("DeleteDevice", parameters);

            return deviceResult;
        }

    }
}