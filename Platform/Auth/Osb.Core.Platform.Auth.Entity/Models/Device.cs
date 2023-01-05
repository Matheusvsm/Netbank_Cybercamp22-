using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class Device : BaseEntity
    {
        public long DeviceId { get; set; }
        public long UserId { get; set; }
        public long CompanyId { get; set; }
        public string Token { get; set; }

        public static Device Create(string token, long userId, long companyId)
        {
            return new Device
            {
                Token = token,
                UserId = userId,
                UpdateUserId = userId,
                CreationUserId = userId,
                CompanyId = companyId
            };
        }
    }
}