using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IAdditionalAccountRepository
    {
        SubAccount Save(SubAccount subAccount, TransactionScope transactionScope = null);
        SpbAccount Save(SpbAccount spbAccount, TransactionScope transactionScope = null);
    }
}