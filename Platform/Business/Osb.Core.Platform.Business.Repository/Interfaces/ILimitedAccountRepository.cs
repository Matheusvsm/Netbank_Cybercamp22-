using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface ILimitedAccountRepository
    {
        LimitedAccount Save(LimitedAccount limitedAccount, TransactionScope transactionScope = null);
        void Update(LimitedAccount limitedAccount, TransactionScope transactionScope = null);
        IEnumerable<LimitedAccount> GetListByStatus(LimitedAccountStatus status);
        LimitedAccount GetById(long limitedAccountId);
    }
}