using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Models.Request;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IPixService
    {
        CreatePixKeyResult CreatePixKey(CreatePixKeyRequest createPixKeyRequest);
        ConfirmPixKeyHoldResult ConfirmPixKeyHold(ConfirmPixKeyHoldRequest confirmPixKeyHoldRequest);
        void UpdatePixKeyStatus(UpdatePixKeyStatusRequest updatePixKeyStatusRequest);
        CancelPixKeyResult CancelPixKey(CancelPixKeyRequest cancelPixKeyRequest);
        ResendPixKeyTokenResult ResendPixKeyToken(ResendPixKeyTokenRequest resendPixKeyTokenRequest);
        void ClaimPixKey(PixKey pixKey);
        IEnumerable<PixKey> FindPixKeyListByStatus(PixKeyStatus pixKeyStatus);
        OperationResult CreateRefundPixIn(RefundPixInRequest refundPixInRequest);
        IEnumerable<RefundPixIn> FindRefundPixInListByStatus(RefundPixInStatus refundPixInStatus);
        void Update(RefundPixIn refundPixIn);
        void GenerateRefundPixIn(RefundPixIn refundPixIn);
        FindInfosPixKeyResult FindInfosPixKey(FindInfosPixKeyRequest findInfosPixKeyRequest);
        FindPixKeyListResult FindPixKeyList(FindPixKeyListRequest findInfosPixKeyRequest);
        OperationResult SavePixOut(GeneratePixOutRequest generatePixOutRequest);
        void GeneratePixOut(PixOut pixOut);
        void UpdatePixOut(PixOut pixOut);
        IEnumerable<PixOut> FindPixOutByStatus(PixOutStatus pixOutStatus);
        PixQRCodeResult GenerateStaticPixQRCode(GenerateStaticPixQRCodeRequest generateStaticPixQRCodeRequest);
        PixQRCodeResult GenerateDynamicPixQrCode(GenerateDynamicPixQrCodeRequest generateDynamicPixQrCodeRequest);
        PixQRCode FindPixQrCode(FindPixQrCodeRequest findPixQrCodeRequest);
        FindInfoPixQRCodeResult FindInfoPixQRCode(FindInfoPixQRCodeRequest findInfoPixQRCodeRequest);
        void UpdatePixKey(PixKey pixKey);
        void NotificationPixIn(PixInRequest updatePixInRequest);
        void UpdateStatus(UpdatePixRequest updatePixOutRequest);
    }
}