/*using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbContext<Account> _context;

        public AccountRepository(IDbContext<Account> context)
        {
            this._context = context;
        }

        public Account Save(Account account, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = account.CompanyId,
                ["paramName"] = account.Name,
                ["paramType"] = account.Type,
                ["paramTaxId"] = account.TaxId,
                ["paramAccountKey"] = account.AccountKey,
                ["paramUserId"] = account.CreationUserId,
                ["paramScore"] = account.Score
            };

            Account accountResult = _context.ExecuteWithSingleResult("InsertAccount", parameters, transactionScope);

            return accountResult;
        }

        public Account GetById(long id)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = id
            };

            Account account = _context.ExecuteWithSingleResult("GetAccountById", parameters);
            return account;
        }

        public Account GetByLogin(string login)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login
            };

            Account account = _context.ExecuteWithSingleResult("GetAccountByLogin", parameters);
            return account;
        }

        public Account GetByTaxId(string taxId, string bank, string bankBranch, string bankAccount, string bankAccountDigit)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramTaxId"] = taxId,
                ["paramBank"] = bank,
                ["paramBankBranch"] = bankBranch,
                ["paramBankAccount"] = bankAccount,
                ["paramBankAccountDigit"] = bankAccountDigit,
            };

            Account account = _context.ExecuteWithSingleResult("GetAccountByTaxId", parameters);
            return account;
        }

        public IEnumerable<Account> GetListByLoginAndCompanyId(string login, long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login,
                ["paramCompanyId"] = companyId
            };

            IEnumerable<Account> account = _context.ExecuteWithMultipleResults("GetAccountListByLoginAndCompanyId", parameters);
            return account;
        }

        public IEnumerable<Account> GetListByUserId(long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId
            };

            IEnumerable<Account> account = _context.ExecuteWithMultipleResults("GetAccountListByUserId", parameters);
            return account;
        }

        public IEnumerable<Account> GetListByUserIdAndCompanyId(long userId, long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId,
                ["paramCompanyId"] = companyId
            };

            IEnumerable<Account> accountList = _context.ExecuteWithMultipleResults("GetAccountListByUserIdAndCompanyId", parameters);

            return accountList;
        }

        public void UpdateAccount(Account account, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = account.AccountId,
                ["paramCompanyId"] = account.CompanyId,
                ["paramName"] = account.Name,
                ["paramType"] = account.Type,
                ["paramTaxId"] = account.TaxId,
                ["paramAccountKey"] = account.AccountKey,
                ["paramUserId"] = account.CreationUserId,
                ["paramScore"] = account.Score

            };

            _context.ExecuteWithNoResult("UpdateAccount", parameters);
        }

        public Account GetByAccountKey(string accountKey)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountKey"] = accountKey
            };

            Account account = _context.ExecuteWithSingleResult("GetAccountByAccountKey", parameters);

            return account;
        }

        public IEnumerable<Account> GetByTaxIdAndCompanyId(string taxId, long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramTaxId"] = taxId,
                ["paramCompanyId"] = companyId
            };

            IEnumerable<Account> accounts = _context.ExecuteWithMultipleResults("GetAccountListByTaxIdAndCompanyId", parameters);

            return accounts;
        }

        public void UpdateUserAccountFixing(long accountId, long userId, bool isFixed)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId,
                ["paramUserId"] = userId,
                ["paramIsFixedAccount"] = isFixed
            };

            _context.ExecuteWithNoResult("UpdateUserAccountFixing", parameters);
        }

        public Account GetByPhoneNumberAndCompanyId(string phoneNumber, long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramPhoneNumber"] = phoneNumber,
                ["paramCompanyId"] = companyId
            };

            Account account = _context.ExecuteWithSingleResult("GetAccountByPhoneNumberAndCompanyId", parameters);

            return account;
        }
        public Account GetBySpbAccount(string spbBank, string spbBankBranch, string spbBankAccount, string spbBankAccountDigit)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramBank"] = spbBank,
                ["paramBankBranch"] = spbBankBranch,
                ["paramBankAccount"] = spbBankAccount,
                ["paramBankAccountDigit"] = spbBankAccountDigit
            };
            Account account = _context.ExecuteWithSingleResult("GetBySpbAccount", parameters);

            return account;
        }

        public Account GetBySpbAccountAndTaxId(string taxId, string spbBank, string spbBankBranch, string spbBankAccount, string spbBankAccountDigit)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramTaxId"] = taxId,
                ["paramSpbBank"] = spbBank,
                ["paramSpbBankBranch"] = spbBankBranch,
                ["paramSpbBankAccount"] = spbBankAccount,
                ["paramSpbBankAccountDigit"] = spbBankAccountDigit
            };
            Account account = _context.ExecuteWithSingleResult("GetBySpbAccountAndTaxId", parameters);

            return account;
        }

        public IEnumerable<Account> GetListByScores(int scores)
        {
            var parameters = new Dictionary<int, dynamic>
            {
                ["paramScores"] = scores
            };

            IEnumerable<Account> account = _context.ExecuteWithMultipleResults("GetAccountListByLoginAndCompanyId", parameters);
            return account;
        }
    }
}*/