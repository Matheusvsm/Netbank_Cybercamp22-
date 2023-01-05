using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IBankingDataRepository
    {
        BankingData Save(BankingData bankingData, TransactionScope transactionScope = null);
        BankingData GetById(long bankingDataId);
        BankingData GetBankingDataByLastid();
    }
}