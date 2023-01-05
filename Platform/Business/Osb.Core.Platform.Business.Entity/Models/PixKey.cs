using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;
namespace Osb.Core.Platform.Business.Entity.Models
{
    public class PixKey : BaseEntity
    {
        public long PixKeyId { get; set; }
        public long AccountId { get; set; }
        public string PixKeyValue { get; set; }
        public PixKeyType PixKeyType { get; set; }
        public PixKeyStatus Status { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public int Attempts { get; set; }

        public static PixKey Create(long accountId, long userId, PixKeyType pixKeyType, string pixKeyValue, PixKeyStatus pixKeyStatus)
        {
            return new PixKey
            {
                AccountId = accountId,
                PixKeyValue = pixKeyValue,
                PixKeyType = pixKeyType,
                Status = pixKeyStatus,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}