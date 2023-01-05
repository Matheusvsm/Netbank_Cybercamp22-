using System;
using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class MoneyTransferRepository : IMoneyTransferRepository
    {
        private readonly IDbContext<MoneyTransfer> _context;

        public MoneyTransferRepository(IDbContext<MoneyTransfer> context)
        {
            this._context = context;
        }

        public MoneyTransfer Save(MoneyTransfer moneyTransfer, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = moneyTransfer.FromAccountId,
                ["paramIdentifier"] = moneyTransfer.Identifier,
                ["paramOperationId"] = moneyTransfer.OperationId,
                ["paramToTaxId"] = moneyTransfer.ToTaxId,
                ["paramToName"] = moneyTransfer.ToName,
                ["paramBankingDataId"] = moneyTransfer.BankingDataId,
                ["paramTransferValue"] = moneyTransfer.TransferValue,
                ["paramTransferDate"] = moneyTransfer.TransferDate,
                ["paramStatus"] = Convert.ChangeType(moneyTransfer.Status, moneyTransfer.Status.GetTypeCode()),
                ["paramDescription"] = moneyTransfer.Description,
                ["paramUserId"] = moneyTransfer.CreationUserId
            };

            MoneyTransfer moneyTransferResult = _context.ExecuteWithSingleResult("InsertMoneyTransfer", parameters, transactionScope);

            return moneyTransferResult;
        }

        public MoneyTransfer GetById(long moneyTransferId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramMoneyTransferId"] = moneyTransferId
            };

            MoneyTransfer moneyTransfer = _context.ExecuteWithSingleResult("GetMoneyTransferById", parameters);
            return moneyTransfer;
        }

        public MoneyTransfer GetByIdentifier(string identifier)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramIdentifier"] = identifier
            };

            MoneyTransfer moneyTransfer = _context.ExecuteWithSingleResult("GetMoneyTransferByIdentifier", parameters);
            return moneyTransfer;
        }

        public IEnumerable<MoneyTransfer> GetByStatus(MoneyTransferStatus status, long? limit = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLimit"] = limit,
                ["paramStatus"] = status
            };

            IEnumerable<MoneyTransfer> moneyTransferList = _context.ExecuteWithMultipleResults("GetMoneyTransferByStatus", parameters);
            return moneyTransferList;
        }

        public void Update(MoneyTransfer moneyTransfer)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = moneyTransfer.MoneyTransferId,
                ["paramExternalIdentifier"] = moneyTransfer.ExternalIdentifier,
                ["paramAttempts"] = moneyTransfer.Attempts,
                ["paramStatus"] = moneyTransfer.Status,
                ["paramUpdateUserId"] = moneyTransfer.UpdateUserId,
                ["paramResponseMessage"] = moneyTransfer.ResponseMessage
            };

            _context.ExecuteWithNoResult("UpdateMoneyTransfer", parameters);
        }

        public MoneyTransfer GetByExternalIdentifier(long externalIdentifier)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramExternalIdentifier"] = externalIdentifier,
            };

            MoneyTransfer moneyTransfer = _context.ExecuteWithSingleResult("getmoneytransferbyexternalidentifier", parameters);
            return moneyTransfer;
        }
    }
}