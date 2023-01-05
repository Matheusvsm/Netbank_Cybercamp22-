using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class BankingData : BaseEntity
    {
        public long BankingDataId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }

        public static BankingData Create(string bank, string bankBranch, string bankAccount, string bankAccountDigit, long userId)
        {
            return new BankingData
            {
                Bank = bank,
                BankBranch = bankBranch,
                BankAccount = bankAccount,
                BankAccountDigit = bankAccountDigit,
                CreationUserId = userId
            };
        }
    }
}