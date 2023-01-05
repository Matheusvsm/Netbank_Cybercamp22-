using System;
using Osb.Core.Api.Application.Util;
using Osb.Core.Api.Application.Models.Request;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Mapping
{
    public class PixMapper
    {
        public BusinessRequest.CreatePixKeyRequest Map(CreatePixKeyRequest createPixKeyRequest)
        {
            return new BusinessRequest.CreatePixKeyRequest
            {
                AccountId = createPixKeyRequest.AccountId,
                UserId = createPixKeyRequest.UserId,
                PixKey = createPixKeyRequest.PixKeyType == PixKeyType.PhoneNumber ? Formatter.FormatPhoneNumber(createPixKeyRequest.PixKey) : createPixKeyRequest.PixKey,
                PixKeyType = createPixKeyRequest.PixKeyType,
                TaxId = createPixKeyRequest.TaxId,
                SPBBank = createPixKeyRequest.SPBBank,
                SPBBankBranch = createPixKeyRequest.SPBBankBranch,
                SPBBankAccount = createPixKeyRequest.SPBBankAccount,
                SPBBankAccountDigit = createPixKeyRequest.SPBBankAccountDigit
            };
        }

        public BusinessRequest.ConfirmPixKeyHoldRequest Map(ConfirmPixKeyHoldRequest confirmPixKeyHoldRequest)
        {
            return new BusinessRequest.ConfirmPixKeyHoldRequest
            {
                AccountId = confirmPixKeyHoldRequest.AccountId,
                UserId = confirmPixKeyHoldRequest.UserId,
                PixKeyValue = confirmPixKeyHoldRequest.PixKeyType != null && confirmPixKeyHoldRequest.PixKeyType == PixKeyType.PhoneNumber ? Formatter.FormatPhoneNumber(confirmPixKeyHoldRequest.PixKeyValue) : confirmPixKeyHoldRequest.PixKeyValue,
                TaxId = confirmPixKeyHoldRequest.TaxId,
                PixKeyType = confirmPixKeyHoldRequest.PixKeyType,
                ConfirmationCode = confirmPixKeyHoldRequest.ConfirmationCode
            };
        }

        public BusinessRequest.ResendPixKeyTokenRequest Map(ResendPixKeyToken resendPixKeyToken)
        {
            return new BusinessRequest.ResendPixKeyTokenRequest
            {
                AccountId = resendPixKeyToken.AccountId,
                UserId = resendPixKeyToken.UserId,
                PixKey = resendPixKeyToken.PixKey,
                TaxId = resendPixKeyToken.TaxId,
                PixKeyType = resendPixKeyToken.PixKeyType
            };
        }

        public BusinessRequest.CancelPixKeyRequest Map(CancelPixKeyRequest cancelPixKeyRequest)
        {
            return new BusinessRequest.CancelPixKeyRequest
            {
                AccountId = cancelPixKeyRequest.AccountId,
                UserId = cancelPixKeyRequest.UserId,
                PixKeyValue = cancelPixKeyRequest.PixKeyValue,
                PixKeyType = cancelPixKeyRequest.PixKeyType,
                TaxId = cancelPixKeyRequest.TaxId,
                SPBBank = cancelPixKeyRequest.SPBBank,
                SPBBankBranch = cancelPixKeyRequest.SPBBankBranch,
                SPBBankAccount = cancelPixKeyRequest.SPBBankAccount,
                SPBBankAccountDigit = cancelPixKeyRequest.SPBBankAccountDigit
            };
        }

        public BusinessRequest.RefundPixInRequest Map(RefundPixInRequest refundPixInRequest)
        {
            return new BusinessRequest.RefundPixInRequest
            {
                AccountId = refundPixInRequest.AccountId,
                UserId = refundPixInRequest.UserId,
                ToTaxId = Formatter.RemoveMaskFromTaxId(refundPixInRequest.ToTaxId),
                ToName = refundPixInRequest.ToName,
                ToBank = refundPixInRequest.ToBank,
                ToBankBranch = refundPixInRequest.ToBankBranch,
                ToBankAccount = refundPixInRequest.ToBankAccount,
                ToBankAccountDigit = refundPixInRequest.ToBankAccountDigit,
                RefundValue = refundPixInRequest.RefundValue,
                CustomerMessage = refundPixInRequest.CustomerMessage,
                DocumentNumber = refundPixInRequest.DocumentNumber,
                Tags = refundPixInRequest.Tags,
            };
        }

        public BusinessRequest.FindInfosPixKeyRequest Map(FindInfosPixKeyRequest findInfosPixKeyRequest)
        {
            if (findInfosPixKeyRequest.PixKeyType == PixKeyType.SocialSecurity || findInfosPixKeyRequest.PixKeyType == PixKeyType.CNPJ)
            {
                findInfosPixKeyRequest.PixKeyValue = Formatter.RemoveMaskFromTaxId(findInfosPixKeyRequest.PixKeyValue);
            }

            else if (findInfosPixKeyRequest.PixKeyType == PixKeyType.PhoneNumber)
            {
                findInfosPixKeyRequest.PixKeyValue = Formatter.RemoveMaskFromPhoneNumber(findInfosPixKeyRequest.PixKeyValue);

                if (findInfosPixKeyRequest.PixKeyValue.Length == 13)
                    findInfosPixKeyRequest.PixKeyValue = "+" + findInfosPixKeyRequest.PixKeyValue;

                findInfosPixKeyRequest.PixKeyValue = "+55" + findInfosPixKeyRequest.PixKeyValue;
            }

            return new BusinessRequest.FindInfosPixKeyRequest
            {
                AccountId = findInfosPixKeyRequest.AccountId,
                UserId = findInfosPixKeyRequest.UserId,
                PixKeyValue = findInfosPixKeyRequest.PixKeyValue.ToLower(),
                TaxId = findInfosPixKeyRequest.TaxId
            };
        }

        public BusinessRequest.FindPixKeyListRequest Map(FindPixKeyListRequest findPixKeyListRequest)
        {
            return new BusinessRequest.FindPixKeyListRequest
            {
                AccountId = findPixKeyListRequest.AccountId,
                UserId = findPixKeyListRequest.UserId,
                TaxId = findPixKeyListRequest.TaxId,
                Bank = findPixKeyListRequest.Bank,
                BankBranch = findPixKeyListRequest.BankBranch,
                BankAccount = findPixKeyListRequest.BankAccount,
                BankAccountDigit = findPixKeyListRequest.BankAccountDigit,
            };
        }

        public BusinessRequest.GeneratePixOutRequest Map(GeneratePixOutRequest generatePixOutRequest)
        {
            return new BusinessRequest.GeneratePixOutRequest
            {
                AccountId = generatePixOutRequest.AccountId,
                UserId = generatePixOutRequest.UserId,
                ToName = generatePixOutRequest.ToName,
                ToTaxId = Formatter.RemoveMaskFromTaxId(generatePixOutRequest.ToTaxId),
                ToBank = generatePixOutRequest.ToBank,
                ToBankBranch = generatePixOutRequest.ToBankBranch,
                ToBankAccount = generatePixOutRequest.ToBankAccount,
                ToBankAccountDigit = generatePixOutRequest.ToBankAccountDigit,
                ToBankName = generatePixOutRequest.ToBankName,
                Value = generatePixOutRequest.Value,
                PaymentDate = generatePixOutRequest.PaymentDate,
                Description = generatePixOutRequest.Description,
                CustomerMessage = generatePixOutRequest.CustomerMessage,
                PixKey = generatePixOutRequest.PixKeyValue,
                PixKeyType = generatePixOutRequest.PixKeyType,
                AccountType = generatePixOutRequest.AccountType,
                SearchProtocol = generatePixOutRequest.SearchProtocol
            };
        }

        public BusinessRequest.GenerateStaticPixQRCodeRequest Map(GenerateStaticPixQRCodeRequest generateStaticPixQRCodeRequest)
        {
            return new BusinessRequest.GenerateStaticPixQRCodeRequest
            {
                AccountId = generateStaticPixQRCodeRequest.AccountId,
                UserId = generateStaticPixQRCodeRequest.UserId,
                PrincipalValue = generateStaticPixQRCodeRequest.PrincipalValue,
                PixKey = generateStaticPixQRCodeRequest.PixKeyValue,
                Address = Map(generateStaticPixQRCodeRequest.Address),
                AdditionalData = generateStaticPixQRCodeRequest.AdditionalData,
                PixTransactionPurpose = generateStaticPixQRCodeRequest.PixTransactionPurpose,
                PixKeyType = generateStaticPixQRCodeRequest.PixKeyType
            };
        }

        public BusinessRequest.PixAddressRequest Map(PixAddressRequest pixAddressRequest)
        {
            return new BusinessRequest.PixAddressRequest
            {
                AddressLine1 = pixAddressRequest.AddressLine1,
                AddressLine2 = pixAddressRequest.AddressLine2,
                ZipCode = pixAddressRequest.ZipCode,
                Neighborhood = pixAddressRequest.Neighborhood,
                CityName = pixAddressRequest.CityName,
                State = pixAddressRequest.State,
                AddressType = pixAddressRequest.AddressType,
                Country = pixAddressRequest.Country,
                Complement = pixAddressRequest.Complement
            };
        }

        public BusinessRequest.GenerateDynamicPixQrCodeRequest Map(GenerateDynamicPixQrCodeRequest generateDynamicPixQrCodeRequest)
        {
            return new BusinessRequest.GenerateDynamicPixQrCodeRequest
            {
                AccountId = generateDynamicPixQrCodeRequest.AccountId,
                UserId = generateDynamicPixQrCodeRequest.UserId,
                PixKey = generateDynamicPixQrCodeRequest.PixKey,
                TaxId = generateDynamicPixQrCodeRequest.TaxId,
                PayerTaxId = generateDynamicPixQrCodeRequest.PayerTaxId,
                PayerName = generateDynamicPixQrCodeRequest.PayerName,
                Value = generateDynamicPixQrCodeRequest.Value,
                Address = generateDynamicPixQrCodeRequest.Address,
                ChangeType = generateDynamicPixQrCodeRequest.ChangeType
            };
        }

        public BusinessRequest.FindInfoPixQRCodeRequest Map(FindInfoPixQRCodeRequest findInfoPixQRCodeRequest)
        {
            return new BusinessRequest.FindInfoPixQRCodeRequest
            {
                AccountId = findInfoPixQRCodeRequest.AccountId,
                UserId = findInfoPixQRCodeRequest.UserId,
                Hash = findInfoPixQRCodeRequest.Hash,
                TaxId = findInfoPixQRCodeRequest.TaxId
            };
        }

        public BusinessRequest.FindPixQrCodeRequest Map(FindPixQrCodeRequest findPixQrCodeRequest)
        {
            return new BusinessRequest.FindPixQrCodeRequest
            {
                AccountId = findPixQrCodeRequest.AccountId,
                UserId = findPixQrCodeRequest.UserId,
                TaxId = findPixQrCodeRequest.TaxId,
                ExternalIdentifier = findPixQrCodeRequest.ExternalIdentifier
            };
        }
    }
}