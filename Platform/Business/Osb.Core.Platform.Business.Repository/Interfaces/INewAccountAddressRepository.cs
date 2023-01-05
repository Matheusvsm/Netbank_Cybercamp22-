using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface INewAccountAddressRepository
    {
        public void Save(NewAccountAddress newAccountAddress, TransactionScope transactionScope = null);
        public IEnumerable<NewAccountAddress> GetByNewAccountId(long newAccountId);
    }
}