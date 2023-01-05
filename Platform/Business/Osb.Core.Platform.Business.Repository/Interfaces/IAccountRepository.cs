using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Account Save(Account account, TransactionScope transactionScope = null);
        void UpdateAccount(Account account, TransactionScope transactionScope = null);
        Account GetByLogin(string login);
        Account GetByTaxId(string taxId, string bank, string bankBranch, string bankAccount, string bankAccountDigit);
        Account GetById(long id);
        Account GetByAccountKey(string accountKey);
        IEnumerable<Account> GetListByLoginAndCompanyId(string login, long companyId);
        IEnumerable<Account> GetListByUserId(long userId);
        IEnumerable<Account> GetListByUserIdAndCompanyId(long userId, long companyId);
        IEnumerable<Account> GetByTaxIdAndCompanyId(string taxId, long companyId);
        void UpdateUserAccountFixing(long accountId, long userId, bool isFixed);
        Account GetByPhoneNumberAndCompanyId(string ToPhoneNumber, long companyId);
        Account GetBySpbAccount(string spbBank, string spbBankBranch, string spbBankAccount, string spbBankAccountDigit);
        Account GetBySpbAccountAndTaxId(string taxId, string spbBank, string spbBankBranch, string spbBankAccount, string spbBankAccountDigit);
        IEnumerable<Account> GetListByScores(int scores);
    }
}