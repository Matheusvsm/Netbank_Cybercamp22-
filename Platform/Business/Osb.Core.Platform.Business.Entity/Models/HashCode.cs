using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class HashCode : BaseEntity
    {
        public string HashCodeId { get; set; }
        public string Value { get; set; }

        public static HashCode Create(string hashCode, long userId)
        {
            return new HashCode
            {
                Value = hashCode,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}