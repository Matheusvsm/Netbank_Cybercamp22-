using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly IDbContext<UserAccount> _context;

        public UserAccountRepository(IDbContext<UserAccount> context)
        {
            this._context = context;
        }

        public void Save(UserAccount userAccount, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = userAccount.AccountId,
                ["paramUserId"] = userAccount.UserId
            };

            _context.ExecuteWithNoResult("InsertUserAccount", parameters, transactionScope);
        }

        public void Update(UserAccount userAccount, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserAccountId"] = userAccount.UserAccountId,
                ["paramDeletionDate"] = userAccount.DeletionDate
            };

            _context.ExecuteWithNoResult("UpdateUserAccount", parameters, transactionScope);
        }

        public UserAccount GetByAccountKeyAndUserId(string accountKey, long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountKey"] = accountKey,
                ["paramUserId"] = userId
            };

            UserAccount result = _context.ExecuteWithSingleResult("GetUserAccountByAccountKeyAndUserId", parameters);

            return result;
        }

        public UserAccount GetUserAccountByUserIdAndAccountId(long userId, long accountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId,
                ["paramUserId"] = userId
            };

            UserAccount userAccount = _context.ExecuteWithSingleResult("GetUserAccountByUserIdAndAccountId", parameters);

            return userAccount;
        }
        public IEnumerable<UserAccount> GetUsersByAccountId(long accountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId
            };

            IEnumerable<UserAccount> result = _context.ExecuteWithMultipleResults("GetUsersByAccountId", parameters);

            return result;
        }
    }
}