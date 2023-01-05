using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class BankingDataRepository : IBankingDataRepository
    {
        private readonly IDbContext<BankingData> _context;

        public BankingDataRepository(IDbContext<BankingData> context)
        {
            this._context = context;
        }

        public BankingData Save(BankingData bankingData, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramBank"] = bankingData.Bank,
                ["paramBankBranch"] = bankingData.BankBranch,
                ["paramBankAccount"] = bankingData.BankAccount,
                ["paramBankAccountDigit"] = bankingData.BankAccountDigit,
                ["paramUserId"] = bankingData.CreationUserId
            };

            BankingData bankingDataResult = _context.ExecuteWithSingleResult("InsertBankingData", parameters, transactionScope);
            return bankingDataResult;
        }

        public BankingData GetById(long bankingDataId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = bankingDataId
            };

            BankingData bankingData = _context.ExecuteWithSingleResult("GetBankingDataById", parameters);
            return bankingData;
        }

        public BankingData GetBankingDataByLastid()
        {
            var parameters = new Dictionary<string, dynamic> { };

            BankingData bankingData = _context.ExecuteWithSingleResult("GetBankingDataByLastid", parameters);
            return bankingData;
        }
    }
}