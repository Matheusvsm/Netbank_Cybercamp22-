using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class NewAccountRepository : INewAccountRepository
    {
        private readonly IDbContext<NewAccount> _context;

        public NewAccountRepository(IDbContext<NewAccount> context)
        {
            this._context = context;
        }

        public NewAccount Save(NewAccount newAccount, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = newAccount.CompanyId,
                ["paramTaxId"] = newAccount.TaxId,
                ["paramPersonName"] = newAccount.PersonName,
                ["paramPhoneNumber"] = newAccount.PhoneNumber,
                ["paramMail"] = newAccount.Mail,
                ["paramNickname"] = newAccount.Nickname,
                ["paramBirthDate"] = newAccount.BirthDate,
                ["paramMotherFullName"] = newAccount.MotherFullName,
                ["paramFatherFullName"] = newAccount.FatherFullName,
                ["paramNationality"] = newAccount.Nationality,
                ["paramBirthCity"] = newAccount.BirthCity,
                ["paramBirthState"] = newAccount.BirthState,
                ["paramGender"] = newAccount.Gender,
                ["paramStatus"] = newAccount.Status,
                ["paramMaritalStatus"] = newAccount.MaritalStatus,
                ["paramSpouseName"] = newAccount.SpouseName,
                ["paramOccupation"] = newAccount.Occupation,
                ["paramCompanyType"] = newAccount.CompanyType,
                ["paramCompanyActivity"] = newAccount.CompanyActivity,
                ["paramConstitutionDate"] = newAccount.ConstitutionDate,
                ["paramPubliclyExposedPerson"] = newAccount.PubliclyExposedPerson,
                ["paramCheckPendingTransfers"] = newAccount.CheckPendingTransfers,
                ["paramIdentityDocument"] = newAccount.IdentityDocument,
                ["paramBank"] = newAccount.Bank,
                ["paramBankBranch"] = newAccount.BankBranch,
                ["paramBankAccount"] = newAccount.BankAccount,
                ["paramBankAccountDigit"] = newAccount.BankAccountDigit,
                ["paramUserId"] = newAccount.CreationUserId
            };

            NewAccount bankingDataResult = _context.ExecuteWithSingleResult("InsertNewAccount", parameters, transactionScope);
            return bankingDataResult;
        }

        public void Update(NewAccount newAccount)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramNewAccountId"] = newAccount.NewAccountId,
                ["paramAttempts"] = newAccount.Attempts,
                ["paramStatus"] = newAccount.Status,
                ["paramUpdateUserId"] = newAccount.UpdateUserId
            };

            _context.ExecuteWithNoResult("UpdateNewAccount", parameters);
        }

        public IEnumerable<NewAccount> GetByStatus(NewAccountStatus status, long? limit = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status,
                ["paramLimit"] = limit
            };

            IEnumerable<NewAccount> newAccountList = _context.ExecuteWithMultipleResults("GetNewAccountByStatus", parameters);

            return newAccountList;
        }

        public NewAccount GetById(long newAccountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramNewAccountId"] = newAccountId
            };

            NewAccount newAccount = _context.ExecuteWithSingleResult("GetNewAccountById", parameters);

            return newAccount;
        }
    }
}