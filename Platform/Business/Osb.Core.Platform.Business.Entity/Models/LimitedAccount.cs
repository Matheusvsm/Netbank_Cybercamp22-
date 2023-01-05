using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class LimitedAccount : BaseEntity
    {
        public long LimitedAccountId { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxId { get; set; }
        public string Mail { get; set; }
        public string Nickname { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public DateTime BirthDate { get; set; }
        public string TradingName { get; set; }
        public string LegalName { get; set; }
        public DateTime? ConstitutionDate { get; set; }
        public LimitedAccountStatus Status { get; set; }
        public string AccountKey { get; set; }
        public int Attempts { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public static LimitedAccount Create(long companyId, string name, string phoneNumber, string taxId, string mail, string nickname, string bank, string bankBranch, string bankAccount, string BankAccountDigit,
            DateTime birthDate, string tradingName, string legalName, DateTime? constitutionDate, long userId)
        {
            return new LimitedAccount
            {
                CompanyId = companyId,
                Name = name,
                PhoneNumber = phoneNumber,
                TaxId = taxId,
                Mail = mail,
                Nickname = nickname,
                Bank = bank,
                BankBranch = bankBranch,
                BankAccount = bankAccount,
                BankAccountDigit = BankAccountDigit,
                BirthDate = birthDate,
                TradingName = tradingName,
                LegalName = legalName,
                ConstitutionDate = constitutionDate,
                Status = LimitedAccountStatus.Created,
                CreationUserId = userId
            };
        }
    }
}