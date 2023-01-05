using System;
using System.Text.RegularExpressions;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.PixMsg;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class PixValidator
    {
        public void Validate(CreatePixKeyRequest request)
        {
            if (!Enum.IsDefined(typeof(PixKeyType), request.PixKeyType))
                throw new OsbBusinessException(PixExcMsg.EXC0001);

            if (request.PixKeyType != PixKeyType.RamdomKeyCode)
                if (string.IsNullOrEmpty(request.PixKey))
                    throw new OsbBusinessException(PixExcMsg.EXC0002);
        }

        public void Validate(CancelPixKeyRequest request)
        {

            if (String.IsNullOrEmpty(request.PixKeyValue))
                throw new OsbBusinessException(PixExcMsg.EXC0003);

            if (String.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(PixExcMsg.EXC0016);

            if (!Enum.IsDefined(typeof(PixKeyType), request.PixKeyType))
                throw new OsbBusinessException(PixExcMsg.EXC0001);
        }

        public void Validate(ResendPixKeyTokenRequest request)
        {
            if (String.IsNullOrEmpty(request.PixKey))
                throw new OsbBusinessException(PixExcMsg.EXC0003);

            if (String.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(PixExcMsg.EXC0016);

            if (!Enum.IsDefined(typeof(PixKeyType), request.PixKeyType))
                throw new OsbBusinessException(PixExcMsg.EXC0001);
        }

        public void Validate(ConfirmPixKeyHoldRequest request)
        {

            if (String.IsNullOrEmpty(request.PixKeyValue))
                throw new OsbBusinessException(PixExcMsg.EXC0003);

            if (!Enum.IsDefined(typeof(PixKeyType), request.PixKeyType))
                throw new OsbBusinessException(PixExcMsg.EXC0001);

            if ((string.IsNullOrEmpty(request.ConfirmationCode)))
                throw new OsbBusinessException(PixExcMsg.EXC0006);
        }

        public void Validate(RefundPixInRequest request)
        {
            if (String.IsNullOrEmpty(request.ToName))
                throw new OsbBusinessException(PixExcMsg.EXC0010);

            if ((String.IsNullOrEmpty(request.ToTaxId)) || (!Regex.IsMatch(request.ToBankAccountDigit, (@"^[0-9]+$"))))
                throw new OsbBusinessException(PixExcMsg.EXC0016);

            if ((String.IsNullOrEmpty(request.ToBank)) || (!Regex.IsMatch(request.ToBankAccountDigit, (@"^[0-9]+$"))))
                throw new OsbBusinessException(PixExcMsg.EXC0011);

            if ((String.IsNullOrEmpty(request.ToBankBranch)) || (!Regex.IsMatch(request.ToBankAccountDigit, (@"^[0-9]+$"))))
                throw new OsbBusinessException(PixExcMsg.EXC0012);

            if ((String.IsNullOrEmpty(request.ToBankAccount)) || (!Regex.IsMatch(request.ToBankAccountDigit, (@"^[0-9]+$"))))
                throw new OsbBusinessException(PixExcMsg.EXC0013);

            if ((String.IsNullOrEmpty(request.ToBankAccountDigit)) || (!Regex.IsMatch(request.ToBankAccountDigit, (@"^[0-9]+$"))))
                throw new OsbBusinessException(PixExcMsg.EXC0014);

            if (request.ToBankAccountDigit.Length > 2)
                throw new OsbBusinessException(PixExcMsg.EXC0017);

            if (request.RefundValue <= decimal.Zero)
                throw new OsbBusinessException(PixExcMsg.EXC0015);

            if (request.DocumentNumber == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0011);
        }

        public void Validate(FindInfosPixKeyRequest request)
        {
            if (String.IsNullOrEmpty(request.PixKeyValue))
                throw new OsbBusinessException(PixExcMsg.EXC0003);

            if (String.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(PixExcMsg.EXC0019);

            if (request.UserId == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0004);

            if (request.AccountId == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0005);
        }

        public void Validate(FindPixKeyListRequest request)
        {
            if (request.UserId == default(long))
            {
                throw new OsbBusinessException(PixExcMsg.EXC0004);
            }
            if (request.AccountId == default(long))
            {
                throw new OsbBusinessException(PixExcMsg.EXC0005);
            }
        }

        public void Validate(GeneratePixOutRequest request)
        {
            if (request.UserId == default(long))
            {
                throw new OsbBusinessException(PixExcMsg.EXC0004);
            }
            if (request.AccountId == default(long))
            {
                throw new OsbBusinessException(PixExcMsg.EXC0005);
            }
            if (request.PaymentDate.Date < DateTime.Today)
                throw new OsbBusinessException(string.Format(PixExcMsg.EXC0020));

            if (request.Value <= decimal.Zero)
                throw new OsbBusinessException(PixExcMsg.EXC0020);

            if (string.IsNullOrEmpty(request.ToTaxId))
                throw new OsbBusinessException(PixExcMsg.EXC0016);
        }

        public void Validate(GenerateStaticPixQRCodeRequest request)
        {
            if (String.IsNullOrEmpty(request.PixKey))
                throw new OsbBusinessException(PixExcMsg.EXC0003);

            if (!Enum.IsDefined(typeof(PixKeyType), request.PixKeyType))
                throw new OsbBusinessException(PixExcMsg.EXC0001);

            if (request.Address == null)
                throw new OsbBusinessException(PixExcMsg.EXC0025);
        }

        public void Validate(GenerateDynamicPixQrCodeRequest request)
        {
            if (request.UserId == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0004);

            if (request.AccountId == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0005);

            if (String.IsNullOrEmpty(request.PixKey))
                throw new OsbBusinessException(PixExcMsg.EXC0003);

            if (String.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(PixExcMsg.EXC0024);

            if (String.IsNullOrEmpty(request.PayerTaxId))
                throw new OsbBusinessException(PixExcMsg.EXC0019);

            if (request.Value == default(decimal))
                throw new OsbBusinessException(PixExcMsg.EXC0020);

            if (request.Address == null)
                throw new OsbBusinessException(PixExcMsg.EXC0025);

            if (!Enum.IsDefined(typeof(ChangeType), request.ChangeType))
                throw new OsbBusinessException(PixExcMsg.EXC0026);
        }

        public void Validate(FindPixQrCodeRequest request)
        {
            if (request.AccountId == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0005);

            if (request.ExternalIdentifier == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0023);

            if (request.AccountId == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0005);

            if (String.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(PixExcMsg.EXC0024);
        }

        public void Validate(UpdatePixKeyStatusRequest request)
        {
            if (String.IsNullOrEmpty(request.Bank))
                throw new OsbBusinessException(PixExcMsg.EXC0011);

            if (String.IsNullOrEmpty(request.BankAccount))
                throw new OsbBusinessException(PixExcMsg.EXC0013);

            if (String.IsNullOrEmpty(request.BankBranch))
                throw new OsbBusinessException(PixExcMsg.EXC0012);

            if (String.IsNullOrEmpty(request.BankAccountDigit))
                throw new OsbBusinessException(PixExcMsg.EXC0014);

            if (!Enum.IsDefined(typeof(PixKeyType), request.PixKeyType))
                throw new OsbBusinessException(PixExcMsg.EXC0001);
        }
        public void Validate(FindInfoPixQRCodeRequest request)
        {
            if (request.UserId == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0004);

            if (request.AccountId == default(long))
                throw new OsbBusinessException(PixExcMsg.EXC0005);

            if (string.IsNullOrEmpty(request.Hash))
                throw new OsbBusinessException(PixExcMsg.EXC0027);

            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(PixExcMsg.EXC0024);
        }
        public void Validate(PixInRequest notifyPixInRequest)
        {
            if (String.IsNullOrEmpty(notifyPixInRequest.ToBankNumber))
                throw new OsbBusinessException(PixExcMsg.EXC0011);

            if (String.IsNullOrEmpty(notifyPixInRequest.ToBankAccount))
                throw new OsbBusinessException(PixExcMsg.EXC0013);

            if (String.IsNullOrEmpty(notifyPixInRequest.ToBankBranch))
                throw new OsbBusinessException(PixExcMsg.EXC0012);

            if (String.IsNullOrEmpty(notifyPixInRequest.ToBankAccountDigit))
                throw new OsbBusinessException(PixExcMsg.EXC0014);

            if (notifyPixInRequest.Value <= 0)
                throw new OsbBusinessException(PixExcMsg.EXC0029);
        }

        public void Validate(UpdatePixRequest UpdatePixRequest)
        {
            if (!Enum.IsDefined<PixOutStatus>(UpdatePixRequest.Status))
                throw new OsbBusinessException(PixExcMsg.EXC0028);

            if (UpdatePixRequest.ExternalIdentifier <= 0)
                throw new OsbBusinessException(PixExcMsg.EXC0023);
        }
    }
}