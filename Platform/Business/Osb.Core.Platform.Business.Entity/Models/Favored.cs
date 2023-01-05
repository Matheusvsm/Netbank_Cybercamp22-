using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class Favored : BaseEntity
    {
        public long FavoredId { get; set; }
        public long AccountId { get; set; }
        public string TaxId { get; set; }
        public string Name { get; set; }
        public OperationType OperationType { get; set; }
        public string BankName { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }

        public static Favored Create(long userId, long accountId, string taxId, string name, OperationType operatioonType, string bankName, string bank, string bankBranch, string bankAccount, string bankAccountDigit)
        {
            return new Favored
            {
                AccountId = accountId,
                TaxId = taxId,
                Name = name,
                OperationType = operatioonType,
                BankName = bankName,
                Bank = bank,
                BankBranch = bankBranch,
                BankAccount = bankAccount,
                BankAccountDigit = bankAccountDigit,
                CreationUserId = userId,
                UpdateUserId = userId,
            };
        }
    }
}