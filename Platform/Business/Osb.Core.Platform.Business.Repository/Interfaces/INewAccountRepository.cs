using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface INewAccountRepository
    {
        NewAccount Save(NewAccount newAccount, TransactionScope transactionScope = null);
        void Update(NewAccount newAccount);
        IEnumerable<NewAccount> GetByStatus(NewAccountStatus status, long? loadValue = null);
        NewAccount GetById(long newAccountId);
    }
}