using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class InternalTransferRepository : IInternalTransferRepository
    {
        private readonly IDbContext<InternalTransfer> _internalTransferContext;
        private readonly IDbContext<PendingInternalTransfer> _pendingInternalTransferContext;

        public InternalTransferRepository(IDbContext<InternalTransfer> internalTransferContext, IDbContext<PendingInternalTransfer> pendingInternalTransferContext)
        {
            this._internalTransferContext = internalTransferContext;
            this._pendingInternalTransferContext = pendingInternalTransferContext;
        }

        public void Save(InternalTransfer internalTransfer, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramIdentifier"] = internalTransfer.Identifier,
                ["paramFromAccountId"] = internalTransfer.FromAccountId,
                ["paramToAccountId"] = internalTransfer.ToAccountId,
                ["paramOperationId"] = internalTransfer.OperationId,
                ["paramTransferValue"] = internalTransfer.TransferValue,
                ["paramTransferDate"] = internalTransfer.TransferDate,
                ["paramStatus"] = internalTransfer.Status,
                ["paramDescription"] = internalTransfer.Description,
                ["paramUserId"] = internalTransfer.CreationUserId
            };

            _internalTransferContext.ExecuteWithNoResult("InsertInternalTransfer", parameters, transactionScope);
        }

        public InternalTransfer GetById(long internalTransferId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = internalTransferId
            };

            InternalTransfer internalTransfer = _internalTransferContext.ExecuteWithSingleResult("GetInternalTransferById", parameters);

            return internalTransfer;
        }

        public InternalTransfer GetByExternalIdentifier(long externalIdentifier)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramExternalIdentifier"] = externalIdentifier
            };

            InternalTransfer internalTransfer = _internalTransferContext.ExecuteWithSingleResult("getinternaltransferbyexternalidentifier", parameters);

            return internalTransfer;
        }

        public IEnumerable<InternalTransfer> GetByStatus(InternalTransferStatus status, long? limit = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLimit"] = limit,
                ["paramStatus"] = status
            };

            IEnumerable<InternalTransfer> internalTransferList = _internalTransferContext.ExecuteWithMultipleResults("GetInternalTransferByStatus", parameters);

            return internalTransferList;
        }

        public void Update(InternalTransfer internalTransfer)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = internalTransfer.InternalTransferId,
                ["paramExternalIdentifier"] = internalTransfer.ExternalIdentifier,
                ["paramStatus"] = internalTransfer.Status,
                ["paramAttempts"] = internalTransfer.Attempts,
                ["paramUpdateUserId"] = internalTransfer.UpdateUserId,
                ["paramResponseMessage"] = internalTransfer.ResponseMessage
            };

            _internalTransferContext.ExecuteWithNoResult("UpdateInternalTransfer", parameters);
        }

        public void Save(PendingInternalTransfer pendingInternalTransfer, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = pendingInternalTransfer.AccountId,
                ["paramOperationId"] = pendingInternalTransfer.OperationId,
                ["paramPhoneNumber"] = pendingInternalTransfer.PhoneNumber,
                ["paramCountryCode"] = pendingInternalTransfer.CountryCode,
                ["paramValue"] = pendingInternalTransfer.Value,
                ["Identifier"] = pendingInternalTransfer.Identifier,
                ["paramFromTaxId"] = pendingInternalTransfer.FromTaxId,
                ["paramFromBank"] = pendingInternalTransfer.FromBank,
                ["paramFromBankBranch"] = pendingInternalTransfer.FromBankBranch,
                ["paramFromBankAccount"] = pendingInternalTransfer.FromBankAccount,
                ["paramFromBankAccountDigit"] = pendingInternalTransfer.FromBankAccountDigit,
                ["paramStatus"] = pendingInternalTransfer.Status,
                ["paramUserId"] = pendingInternalTransfer.CreationUserId
            };

            _pendingInternalTransferContext.ExecuteWithNoResult("InsertPendingInternalTransfer", parameters, transactionScope);
        }

        public void Update(PendingInternalTransfer pendingInternalTransfer)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramPendingInternalTransferId"] = pendingInternalTransfer.PendingInternalTransferId,
                ["paramStatus"] = pendingInternalTransfer.Status,
                ["paramAttempts"] = pendingInternalTransfer.Attempts,
                ["paramUpdateUserId"] = pendingInternalTransfer.UpdateUserId,
                ["paramExternalIdentifier"] = pendingInternalTransfer.ExternalIdentifier
            };

            _pendingInternalTransferContext.ExecuteWithNoResult("UpdatePendingInternalTransfer", parameters);
        }

        public IEnumerable<PendingInternalTransfer> GetListByStatus(PendingInternalTransferStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            IEnumerable<PendingInternalTransfer> pendingInternalTransferSList = _pendingInternalTransferContext.ExecuteWithMultipleResults("GetPendingInternalTransferListByStatus", parameters);

            return pendingInternalTransferSList;
        }
    }
}