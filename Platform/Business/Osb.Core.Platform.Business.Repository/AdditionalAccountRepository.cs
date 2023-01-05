using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class AdditionalAccountRepository : IAdditionalAccountRepository
    {
        private readonly IDbContext<SubAccount> _subAccountContext;
        private readonly IDbContext<SpbAccount> _spbAccountContext;

        public AdditionalAccountRepository(IDbContext<SubAccount> subAccountContext, IDbContext<SpbAccount> spbAccountContext)
        {
            this._subAccountContext = subAccountContext;
            this._spbAccountContext = spbAccountContext;
        }

        public SubAccount Save(SubAccount subAccount, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramBank"] = subAccount.Bank,
                ["paramAccountId"] = subAccount.AccountId,
                ["paramBankBranch"] = subAccount.BankBranch,
                ["paramBankAccount"] = subAccount.BankAccount,
                ["paramBankAccountDigit"] = subAccount.BankAccountDigit,
                ["paramUserId"] = subAccount.CreationUserId
            };

            SubAccount subAccountResult = _subAccountContext.ExecuteWithSingleResult("InsertSubAccount", parameters, transactionScope);

            return subAccountResult;
        }

        public SpbAccount Save(SpbAccount spbAccount, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramBank"] = spbAccount.Bank,
                ["paramAccountId"] = spbAccount.AccountId,
                ["paramBankBranch"] = spbAccount.BankBranch,
                ["paramBankAccount"] = spbAccount.BankAccount,
                ["paramBankAccountDigit"] = spbAccount.BankAccountDigit,
                ["paramUserId"] = spbAccount.CreationUserId
            };

            SpbAccount spbAccountResult = _spbAccountContext.ExecuteWithSingleResult("InsertSpbAccount", parameters, transactionScope);

            return spbAccountResult;
        }
    }
}