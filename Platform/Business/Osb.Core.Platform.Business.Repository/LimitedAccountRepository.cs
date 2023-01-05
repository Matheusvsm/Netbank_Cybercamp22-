using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class LimitedAccountRepository : ILimitedAccountRepository
    {
        private readonly IDbContext<LimitedAccount> _context;

        public LimitedAccountRepository(IDbContext<LimitedAccount> context)
        {
            this._context = context;
        }

        public LimitedAccount Save(LimitedAccount limitedAccount, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = limitedAccount.CompanyId,
                ["paramName"] = limitedAccount.Name,
                ["paramPhoneNumber"] = limitedAccount.PhoneNumber,
                ["paramTaxId"] = limitedAccount.TaxId,
                ["paramMail"] = limitedAccount.Mail,
                ["paramNickname"] = limitedAccount.Nickname,
                ["paramBank"] = limitedAccount.Bank,
                ["paramBankBranch"] = limitedAccount.BankBranch,
                ["paramBankAccount"] = limitedAccount.BankAccount,
                ["paramBankAccountDigit"] = limitedAccount.BankAccountDigit,
                ["paramBirthDate"] = limitedAccount.BirthDate,
                ["paramTradingName"] = limitedAccount.TradingName,
                ["paramLegalName"] = limitedAccount.LegalName,
                ["paramConstitutionDate"] = limitedAccount.ConstitutionDate,
                ["paramPassword"] = limitedAccount.Password,
                ["paramSalt"] = limitedAccount.Salt,
                ["paramStatus"] = LimitedAccountStatus.Created,
                ["paramUserId"] = limitedAccount.CreationUserId
            };

            LimitedAccount result = _context.ExecuteWithSingleResult("InsertLimitedAccount", parameters, transactionScope);

            return result;
        }

        public void Update(LimitedAccount limitedAccount, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLimitedAccountId"] = limitedAccount.LimitedAccountId,
                ["paramStatus"] = limitedAccount.Status,
                ["paramAccountKey"] = limitedAccount.AccountKey,
                ["paramAttempts"] = limitedAccount.Attempts,
                ["paramUpdateUserId"] = limitedAccount.UpdateUserId
            };

            _context.ExecuteWithNoResult("UpdateLimitedAccount", parameters, transactionScope);
        }

        public IEnumerable<LimitedAccount> GetListByStatus(LimitedAccountStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            IEnumerable<LimitedAccount> limitedAccountList = _context.ExecuteWithMultipleResults("GetLimitedAccountListByStatus", parameters);

            return limitedAccountList;
        }

        public LimitedAccount GetById(long limitedAccountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLimitedAccountId"] = limitedAccountId
            };

            LimitedAccount limitedAccount = _context.ExecuteWithSingleResult("GetLimitedAccountById", parameters);

            return limitedAccount;
        }
    }
}