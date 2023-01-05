using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class SpbAccount : BaseEntity
    {
        public long SpbAccountId { get; set; }
        public long AccountId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }

        public static SpbAccount Create(long accountId, string bank, string bankBranch, string bankAccount, string bankAccountDigit, long userId)
        {
            return new SpbAccount
            {
                AccountId = accountId,
                Bank = bank,
                BankBranch = bankBranch,
                BankAccount = bankAccount,
                BankAccountDigit = bankAccountDigit,
                CreationUserId = userId,
                UpdateUserId = userId
            };
        }
    }
}