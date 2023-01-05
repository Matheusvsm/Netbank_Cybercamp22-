using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class PixRepository : IPixRepository
    {
        private readonly IDbContext<RefundPixIn> _refundPixInContext;
        private readonly IDbContext<PixOut> _context;
        private readonly IDbContext<StaticPixQRCode> _staticPixQRCodeContext;
        private readonly IDbContext<DynamicPixQrCode> _dynamicPixQrCodecontext;
        private readonly IDbContext<PixQRCode> _pixQRCodeContext;
        private readonly IDbContext<PixKey> _pixKeyContext;

        public PixRepository(IDbContext<StaticPixQRCode> StaticPixQRCodeContext, IDbContext<DynamicPixQrCode> dynamicPixQRCodeContext, IDbContext<PixQRCode> pixQRCodeContext, IDbContext<RefundPixIn> refundPixInContext, IDbContext<PixOut> context, IDbContext<PixKey> pixKeyContext)
        {
            this._refundPixInContext = refundPixInContext;
            this._context = context;
            this._staticPixQRCodeContext = StaticPixQRCodeContext;
            this._dynamicPixQrCodecontext = dynamicPixQRCodeContext;
            this._pixQRCodeContext = pixQRCodeContext;
            this._pixKeyContext = pixKeyContext;
        }

        public void Save(PixOut pixOut, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = pixOut.AccountId,
                ["paramOperationId"] = pixOut.OperationId,
                ["paramToName"] = pixOut.ToName,
                ["paramToTaxId"] = pixOut.ToTaxId,
                ["paramToBank"] = pixOut.ToBank,
                ["paramToBankBranch"] = pixOut.ToBankBranch,
                ["paramToBankAccount"] = pixOut.ToBankAccount,
                ["paramToBankAccountDigit"] = pixOut.ToBankAccountDigit,
                ["paramValue"] = pixOut.Value,
                ["paramStatus"] = pixOut.Status,
                ["paramPaymentDate"] = pixOut.PaymentDate,
                ["paramIdentifier"] = pixOut.Identifier,
                ["paramCustomerMessage"] = pixOut.CustomerMessage,
                ["paramPixKey"] = pixOut.PixKey,
                ["paramPixKeyType"] = pixOut.PixKeyType,
                ["paramAccountType"] = pixOut.AccountType,
                ["paramDescription"] = pixOut.Description,
                ["paramSearchProtocol"] = pixOut.SearchProtocol,
                ["paramUserId"] = pixOut.CreationUserId
            };

            _context.ExecuteWithNoResult("InsertPixOut", parameters, transactionScope);
        }

        public void Update(PixOut pixOut)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = pixOut.PixOutId,
                ["paramExternalIdentifier"] = pixOut.ExternalIdentifier,
                ["paramResponseMessage"] = pixOut.ResponseMessage,
                ["paramAttempts"] = pixOut.Attempts,
                ["paramStatus"] = pixOut.Status
            };

            _context.ExecuteWithNoResult("UpdatePixOut", parameters);
        }

        public IEnumerable<PixOut> GetByStatus(PixOutStatus pixOutStatus)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = pixOutStatus
            };

            return _context.ExecuteWithMultipleResults("GetPixOutByStatus", parameters);
        }

        public IEnumerable<PixKey> GetPixKeyListByStatus(PixKeyStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            return _pixKeyContext.ExecuteWithMultipleResults("GetPixKeyListByStatus", parameters);
        }

        public void Save(RefundPixIn refundPixIn, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = refundPixIn.AccountId,
                ["paramOperationId"] = refundPixIn.OperationId,
                ["paramToTaxId"] = refundPixIn.ToTaxId,
                ["paramToName"] = refundPixIn.ToName,
                ["paramToBank"] = refundPixIn.ToBank,
                ["paramToBankBranch"] = refundPixIn.ToBankBranch,
                ["paramToBankAccount"] = refundPixIn.ToBankAccount,
                ["paramToBankAccountDigit"] = refundPixIn.ToBankAccountDigit,
                ["paramRefundValue"] = refundPixIn.RefundValue,
                ["paramCustomerMessage"] = refundPixIn.CustomerMessage,
                ["paramDocumentNumber"] = refundPixIn.DocumentNumber,
                ["paramIdentifier"] = refundPixIn.Identifier,
                ["paramStatus"] = refundPixIn.Status,
                ["paramUserId"] = refundPixIn.CreationUserId
            };

            _refundPixInContext.ExecuteWithNoResult("InsertRefundPixIn", parameters, transactionScope);
        }

        public void Update(RefundPixIn refundPixIn)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramRefundPixInId"] = refundPixIn.RefundPixInId,
                ["paramStatus"] = refundPixIn.Status,
                ["paramAttempts"] = refundPixIn.Attempts,
                ["paramExternalIdentifier"] = refundPixIn.ExternalIdentifier,
                ["paramUpdateUserId"] = refundPixIn.UpdateUserId
            };

            _refundPixInContext.ExecuteWithNoResult("UpdateRefundPixIn", parameters);
        }

        public IEnumerable<RefundPixIn> GetByStatus(RefundPixInStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            return _refundPixInContext.ExecuteWithMultipleResults("GetRefundPixInByStatus", parameters);
        }

        public StaticPixQRCode SaveStaticPixQRCode(long externalIdentifier, string qrCode, string hashCode, PixKeyType pixKeyType, long userId, long accountId, TransactionScope transactionScope = null)
        {

            var parameters = new Dictionary<string, dynamic>
            {
                ["paramExternalIdentifier"] = externalIdentifier,
                ["paramQRCode"] = qrCode,
                ["paramHashCode"] = hashCode,
                ["paramPixKeyType"] = pixKeyType,
                ["paramUserId"] = userId,
                ["paramAccountId"] = accountId
            };

            return _staticPixQRCodeContext.ExecuteWithSingleResult("insertstaticpixqrcode", parameters, transactionScope);
        }

        public StaticPixQRCode GetStaticPixQRCode(PixKeyType pixKeyType, long userId, long accountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramPixKeyType"] = pixKeyType,
                ["paramUserId"] = userId,
                ["paramAccountId"] = accountId
            };

            StaticPixQRCode staticPixQRCode = _staticPixQRCodeContext.ExecuteWithSingleResult("GetStaticPixQRCode", parameters);

            return staticPixQRCode;
        }

        public PixKey GetPixKeyByPixKeyId(long pixKeyId)
        {
            var parameter = new Dictionary<string, dynamic>
            {
                ["paramPixKeyId"] = pixKeyId
            };

            PixKey pixKey = _pixKeyContext.ExecuteWithSingleResult("GetPixKeyByPixKeyId", parameter);

            return pixKey;
        }

        public PixKey SavePixKey(PixKey pixKey, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = pixKey.AccountId,
                ["paramPixKey"] = pixKey.PixKeyValue,
                ["paramStatus"] = pixKey.Status,
                ["paramPixKeyType"] = pixKey.PixKeyType,
                ["paramUserId"] = pixKey.CreationUserId
            };

            PixKey pixKeyResult = _pixKeyContext.ExecuteWithSingleResult("InsertPixKey", parameters, transactionScope);

            return pixKeyResult;
        }

        public IEnumerable<PixKey> GetPixKeyListByAccountId(long accountId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = accountId
            };

            IEnumerable<PixKey> pixKeys = _pixKeyContext.ExecuteWithMultipleResults("GetPixKeyListByAccountId", parameters);

            return pixKeys;
        }

        public void UpdatePixKey(PixKey pixKey)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramPixKeyId"] = pixKey.PixKeyId,
                ["paramStatus"] = pixKey.Status,
                ["paramPixKeyValue"] = pixKey.PixKeyValue
            };

            _pixKeyContext.ExecuteWithNoResult("UpdatePixKeyStatus", parameters);
        }

        public PixKey GetPixKeyByPixKeyValue(PixKeyType type, string pixKey)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramPixKey"] = pixKey,
                ["paramPixKeyType"] = type
            };

            PixKey pixkey = _pixKeyContext.ExecuteWithSingleResult("GetPixKeyByPixKeyValue", parameters);

            return pixkey;
        }


        public PixKey GetPixKeyByAccountData(string pixKeyValue, PixKeyType pixKeyType, string bank, string bankBranch, string bankAccount, string bankAccountDigit)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramPixKeyValue"] = pixKeyValue,
                ["paramPixKeyType"] = pixKeyType,
                ["paramBank"] = bank,
                ["paramBankBranch"] = bankBranch,
                ["paramBankAccount"] = bankAccount,
                ["paramBankAccountDigit"] = bankAccountDigit

            };
            PixKey pixkey = _pixKeyContext.ExecuteWithSingleResult("GetPixKeyByAccountData", parameters);

            return pixkey;

        }
        public PixOut GetByExternalIdentifier(long externalIdentifier)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramExternalIdentifier"] = externalIdentifier,
            };

            PixOut pixOut = _context.ExecuteWithSingleResult("GetPixOutByExternalIdentifier", parameters);
            return pixOut;
        }

        public PixOut GetById(long PixOutId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramPixOutId"] = PixOutId
            };

            PixOut pixOut = _context.ExecuteWithSingleResult("GetPixOutById", parameters);
            return pixOut;
        }

    }
}