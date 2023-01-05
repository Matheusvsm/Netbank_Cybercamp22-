using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IUserAccountRepository
    {
        void Save(UserAccount userAccount, TransactionScope transactionScope = null);
        void Update(UserAccount userAccount, TransactionScope transactionScope = null);
        public UserAccount GetByAccountKeyAndUserId(string accountKey, long userId);
        public UserAccount GetUserAccountByUserIdAndAccountId(long userId, long accountId);
        public IEnumerable<UserAccount> GetUsersByAccountId(long accountId);
    }
}


