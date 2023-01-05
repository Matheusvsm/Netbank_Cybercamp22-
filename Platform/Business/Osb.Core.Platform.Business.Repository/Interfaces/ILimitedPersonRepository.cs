using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface ILimitedPersonRepository
    {
        LimitedPerson Save(LimitedPerson limitedAccount, TransactionScope transactionScope = null);
        IEnumerable<LimitedPerson> GetByLimitedAccountId(long limitedAccountId);
    }
}