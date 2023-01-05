using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface INewAccountPersonRepository
    {
        public NewAccountPerson Save(NewAccountPerson newAccountPerson, TransactionScope transactionScope = null);
        public IEnumerable<NewAccountPerson> GetByNewAccountId(long newAccountId);
    }
}