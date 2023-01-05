using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Common.Entity;
using System;

namespace Osb.Core.Platform.Business.Repository
{
    public class TopUpRepository : ITopUpRepository
    {
        private readonly IDbContext<TopUp> _context;

        public TopUpRepository(IDbContext<TopUp> context)
        {
            this._context = context;
        }

        public void Save(TopUp topUp, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = topUp.AccountId,
                ["paramProductType"] = topUp.ProductType,
                ["paramBatchIdentifier"] = topUp.BatchIdentifier,
                ["paramProductKey"] = topUp.ProductKey,
                ["paramProductValue"] = topUp.ProductValue,
                ["paramContractIdentifier"] = topUp.ContractIdentifier,
                ["paramOriginNSU"] = topUp.OriginNSU,
                ["paramStatus"] = topUp.Status,
                ["paramOperationId"] = topUp.OperationId,
                ["paramUserId"] = topUp.CreationUserId,
                ["paramPeriodicRepetition"] = topUp.PeriodicRepetition,
                ["paramTopUpDate"] = topUp.TopUpDate,
                ["paramIsRecurrent"] = topUp.IsRecurrent,
            };

            _context.ExecuteWithNoResult("InsertTopUp", parameters, transactionScope);
        }

        public IEnumerable<TopUp> GetByStatus(TopUpStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            IEnumerable<TopUp> topUps = _context.ExecuteWithMultipleResults("GetTopUpListByStatus", parameters);

            return topUps;
        }

        public IEnumerable<TopUp> GetByStatusAndDate(TopUpStatus status, DateTime topUpDate)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status,
                ["paramTopUpDate"] = topUpDate
            };

            IEnumerable<TopUp> topUps = _context.ExecuteWithMultipleResults("GetTopUpListByStatusAndDate", parameters);

            return topUps;
        }

        public TopUp GetTopUpByExternalIdentifierAndProductkey(string productKey, long externalIdentifier)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramProductKey"] = productKey,
                ["paramExternalIdentifier"] = externalIdentifier
            };

            TopUp topUp = _context.ExecuteWithSingleResult("GetTopUpByExternalIdentifierAndProductkey", parameters);

            return topUp;
        }

        public void Update(TopUp topUp)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramTopUpId"] = topUp.TopUpId,
                ["paramExternalIdentifier"] = topUp.ExternalIdentifier,
                ["paramUrlReceipt"] = topUp.UrlReceipt != null ? topUp.UrlReceipt : string.Empty,
                ["paramOriginNSU"] = topUp.OriginNSU,
                ["paramBatchIdentifier"] = topUp.BatchIdentifier,
                ["paramProductKey"] = topUp.ProductKey,
                ["paramStatus"] = topUp.Status,
                ["paramAttempts"] = topUp.Attempts,
                ["paramUpdateUserId"] = topUp.UpdateUserId
            };

            _context.ExecuteWithNoResult("UpdateTopUp", parameters);
        }
        public IEnumerable<TopUp> GetTopUpPeriodicList(long accountId, TopUpStatus topUpStatus)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId,
                ["paramStatus"] = topUpStatus
            };

            IEnumerable<TopUp> topUps = _context.ExecuteWithMultipleResults("GetTopUpPeriodicList", parameters);
            return topUps;
        }
    }
}
