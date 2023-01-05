using Osb.Core.Platform.Common.Entity;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository.Interfaces
{
    public interface IPixRepository
    {
        void Save(PixOut pixOut, TransactionScope transactionScope = null);
        void Update(PixOut pixOut);
        void UpdatePixKey(PixKey pixKey);
        PixKey SavePixKey(PixKey pixKey, TransactionScope transactionScope = null);
        IEnumerable<PixKey> GetPixKeyListByAccountId(long accountId);
        PixKey GetPixKeyByPixKeyId(long pixKeyId);
        PixKey GetPixKeyByPixKeyValue(PixKeyType type, string pixKey);
        PixKey GetPixKeyByAccountData(string pixKeyValue, PixKeyType pixKeyType, string bank, string bankBranch, string bankAccount, string bankAccountDigit);
        IEnumerable<PixOut> GetByStatus(PixOutStatus pixOutStatus);
        IEnumerable<PixKey> GetPixKeyListByStatus(PixKeyStatus status);
        void Save(RefundPixIn refundPixIn, TransactionScope transactionScope = null);
        void Update(RefundPixIn refundPixIn);
        IEnumerable<RefundPixIn> GetByStatus(RefundPixInStatus status);
        StaticPixQRCode SaveStaticPixQRCode(long documentNumber, string qrCode, string hashCode, PixKeyType pixKeyType, long userId, long accountId, TransactionScope transactionScope = null);
        StaticPixQRCode GetStaticPixQRCode(PixKeyType pixKeyType, long accountId, long userId);
        PixOut GetById(long PixOutId);
        PixOut GetByExternalIdentifier(long externalIdentifier);
    }

}