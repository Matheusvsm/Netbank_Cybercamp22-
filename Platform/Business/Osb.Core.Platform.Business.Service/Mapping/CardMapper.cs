using System;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Util.Security;
using Osb.Core.Platform.Business.Service.Models.Result;
using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;
using System.Linq;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class CardMapper
    {

        public IntegrationRequest.FindCardRequest Map(BusinessRequest.FindCardRequest findCardRequest)
        {
            return new IntegrationRequest.FindCardRequest
            {
                IdentifierCard = findCardRequest.IdentifierCard,
                AccountId = findCardRequest.AccountId,
                UserId = findCardRequest.UserId
            };
        }

        public IntegrationRequest.FindCardRequest Map(BusinessRequest.VerifyCardRequest verifyCardRequest)
        {
            return new IntegrationRequest.FindCardRequest
            {
                IdentifierCard = verifyCardRequest.IdentifierCard,
                CompanyId = verifyCardRequest.CompanyId,
                UserId = verifyCardRequest.UserId
            };
        }

        public FindCardResult Map(IntegrationResponse.FindCardResponse response)
        {
            return new FindCardResult
            {
                CardHolderName = response.CardHolderName,
                CardHolderTaxId = response.CardHolderTaxId,
                CardOwnerName = response.CardOwnerName,
                CardOwnerTaxId = response.CardOwnerTaxId,
                Type = response.Type,
                Status = response.Status,
                PanLastDigits = response.PanLastDigits,
                ExpirationDate = response.ExpirationDate,
                UnlockedDate = response.UnlockedDate,
                LastBlockedDate = response.LastBlockedDate,
                IsBlocked = response.IsBlocked
            };
        }

        public ChangePinCard MapEncrypted(ChangePinCard changePinCard, string aesIV, string aesKey)
        {
            string generatedSalt = SHA512Provider.GenerateSalt();

            return new ChangePinCard
            {
                IdentifierCard = changePinCard.IdentifierCard,
                AccountId = changePinCard.AccountId,
                OperationId = changePinCard.OperationId,
                CurrentPin = AesProvider.Encrypt(changePinCard.CurrentPin, generatedSalt, aesKey, aesIV),
                Pin = AesProvider.Encrypt(changePinCard.Pin, generatedSalt, aesKey, aesIV),
                ConfirmationPin = AesProvider.Encrypt(changePinCard.ConfirmationPin, generatedSalt, aesKey, aesIV),
                Salt = generatedSalt,
                CreationUserId = changePinCard.CreationUserId,
                UpdateUserId = changePinCard.UpdateUserId
            };
        }

        public IntegrationRequest.ChangePinCardRequest Map(ChangePinCard request, string aesIV, string aesKey)
        {
            return new IntegrationRequest.ChangePinCardRequest
            {
                IdentifierCard = request.IdentifierCard,
                AccountId = request.AccountId,
                CurrentPin = Base64Encode(AesProvider.Decrypt(request.CurrentPin, request.Salt, aesKey, aesIV)),
                Pin = Base64Encode(AesProvider.Decrypt(request.Pin, request.Salt, aesKey, aesIV)),
                PinCheck = Base64Encode(AesProvider.Decrypt(request.ConfirmationPin, request.Salt, aesKey, aesIV)),
                Salt = request.Salt,
                UserId = request.CreationUserId
            };
        }

        public BlockCard MapEncrypted(BlockCard blockCard, string aesIV, string aesKey)
        {
            string generatedSalt = SHA512Provider.GenerateSalt();

            return new BlockCard
            {
                AccountId = blockCard.AccountId,
                IdentifierCard = blockCard.IdentifierCard,
                OperationId = blockCard.OperationId,
                Pin = AesProvider.Encrypt(blockCard.Pin, generatedSalt, aesKey, aesIV),
                Salt = generatedSalt,
                CreationUserId = blockCard.CreationUserId,
                UpdateUserId = blockCard.UpdateUserId
            };
        }

        public IntegrationRequest.BlockCardRequest Map(BlockCard blockCard, string aesIV, string aesKey)
        {
            return new IntegrationRequest.BlockCardRequest
            {
                IdentifierCard = blockCard.IdentifierCard,
                AccountId = blockCard.AccountId,
                Pin = Base64Encode(AesProvider.Decrypt(blockCard.Pin, blockCard.Salt, aesKey, aesIV)),
                ReasonCode = Enum.GetName(blockCard.ReasonCode),
                UserId = blockCard.CreationUserId
            };
        }

        public UnblockCard MapEncrypted(UnblockCard blockCard, string aesIV, string aesKey)
        {
            string generatedSalt = SHA512Provider.GenerateSalt();

            return new UnblockCard
            {
                AccountId = blockCard.AccountId,
                IdentifierCard = blockCard.IdentifierCard,
                OperationId = blockCard.OperationId,
                Pin = AesProvider.Encrypt(blockCard.Pin, generatedSalt, aesKey, aesIV),
                Salt = generatedSalt,
                CreationUserId = blockCard.CreationUserId,
                UpdateUserId = blockCard.UpdateUserId
            };
        }

        public IntegrationRequest.UnblockCardRequest Map(UnblockCard unblockCard, string aesIV, string aesKey)
        {
            return new IntegrationRequest.UnblockCardRequest
            {
                IdentifierCard = unblockCard.IdentifierCard,
                AccountId = unblockCard.AccountId,
                Pin = Base64Encode(AesProvider.Decrypt(unblockCard.Pin, unblockCard.Salt, aesKey, aesIV)),
                UserId = unblockCard.CreationUserId
            };
        }

        public InactivateCard MapEncrypted(InactivateCard inactivateCard, string aesIV, string aesKey)
        {
            string generatedSalt = SHA512Provider.GenerateSalt();

            return new InactivateCard
            {
                AccountId = inactivateCard.AccountId,
                OperationId = inactivateCard.OperationId,
                IdentifierCard = inactivateCard.IdentifierCard,
                ReasonCode = inactivateCard.ReasonCode,
                Status = inactivateCard.Status,
                Pin = AesProvider.Encrypt(inactivateCard.Pin, generatedSalt, aesKey, aesIV),
                Salt = generatedSalt,
                CreationUserId = inactivateCard.CreationUserId,
                UpdateUserId = inactivateCard.UpdateUserId
            };
        }

        public IntegrationRequest.InactivateAndReissueCardRequest Map(InactivateCard inactivateCard, string aesIV, string aesKey, BusinessRequest.InactivateAndReissueCardRequest request)
        {
            return new IntegrationRequest.InactivateAndReissueCardRequest
            {
                IdentifierCard = inactivateCard.IdentifierCard,
                AccountId = inactivateCard.AccountId,
                Pin = Base64Encode(AesProvider.Decrypt(inactivateCard.Pin, inactivateCard.Salt, aesKey, aesIV)),
                ReasonCode = Enum.GetName(inactivateCard.ReasonCode),
                UserId = inactivateCard.UpdateUserId,
                CardDeliveryAddress = Map(request.CardDeliveryAddress)
            };
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public IntegrationRequest.FindCardListRequest Map(Account account)
        {
            return new IntegrationRequest.FindCardListRequest
            {
                AccountId = account.AccountId,
                TaxId = account.TaxId,
                UserId = account.CreationUserId
            };
        }

        public IntegrationRequest.CancelCardRequest Map(CancelCard cancelCard)
        {
            return new IntegrationRequest.CancelCardRequest
            {
                AccountId = cancelCard.AccountId,
                IdentifierCard = cancelCard.IdentifierCard,
                UserId = cancelCard.CreationUserId
            };
        }

        public FindCardListResult Map(IEnumerable<Card> cards)
        {
            return new FindCardListResult
            {
                Cards = cards.Where(card => card.Status != CardStatus.Canceled)
            };
        }

        public CardResult Map(dynamic cardResponse)
        {
            return new CardResult
            {
                Status = cardResponse.ResponseStatus,
                Message = cardResponse.Message
            };
        }

        public IntegrationRequest.ActivateCardRequest Map(ActivateCard activateCard)
        {
            return new IntegrationRequest.ActivateCardRequest
            {
                AccountId = activateCard.AccountId,
                IdentifierCard = activateCard.IdentifierCard,
                UserId = activateCard.CreationUserId
            };
        }

        public IntegrationRequest.BindUnnamedCardRequest Map(BindCard bindCard, CardOwner cardOwner, CardHolder cardHolder, CardHolderContact cardHolderContact)
        {
            return new IntegrationRequest.BindUnnamedCardRequest
            {
                AccountId = bindCard.AccountId,
                CardOwner = Map(cardOwner),
                CardHolder = Map(cardHolder),
                CardHolderContact = Map(cardHolderContact),
                IdentifierCard = bindCard.IdentifierCard,
                UsageType = Enum.GetName(bindCard.UsageType),
                UserId = bindCard.CreationUserId
            };
        }

        public IntegrationRequest.CardOwnerRequest Map(CardOwner cardOwner)
        {
            return new IntegrationRequest.CardOwnerRequest
            {
                OwnerTaxNumber = cardOwner.OwnerTaxId,
                FullName = cardOwner.FullName,
                Phone = cardOwner.Phone,
                Mail = cardOwner.Mail,
                Bank = cardOwner.Bank,
                BankBranch = cardOwner.BankBranch,
                BankAccount = cardOwner.BankAccount,
                BankAccountDigit = cardOwner.BankAccountDigit
            };
        }

        public IntegrationRequest.CardHolderRequest Map(CardHolder cardHolder)
        {
            return new IntegrationRequest.CardHolderRequest
            {
                HolderTaxNumber = cardHolder.HolderTaxId,
                Nationality = cardHolder.Nationality,
                MotherName = cardHolder.MotherName,
                Gender = Enum.GetName(cardHolder.Gender),
                FullName = cardHolder.FullName,
                BirthDate = cardHolder.BirthDate.ToString(),
                MaritalStatus = Enum.GetName(cardHolder.MaritalStatus)
            };
        }

        public IntegrationRequest.CardHolderContactRequest Map(CardHolderContact cardHolderContact)
        {
            return new IntegrationRequest.CardHolderContactRequest
            {
                Phone = cardHolderContact.Phone,
                Mail = cardHolderContact.Mail
            };
        }

        public IntegrationRequest.CardDeliveryAddressRequest Map(CardDeliveryAddressRequest cardDeliveryAddress)
        {
            return new IntegrationRequest.CardDeliveryAddressRequest
            {
                Street = cardDeliveryAddress.Street,
                Number = cardDeliveryAddress.Number,
                Complement = cardDeliveryAddress.Complement,
                Reference = cardDeliveryAddress.Reference,
                District = cardDeliveryAddress.Street,
                ZipCode = cardDeliveryAddress.ZipCode,
                City = cardDeliveryAddress.City,
                State = cardDeliveryAddress.State,
                Country = cardDeliveryAddress.Country
            };
        }
    }
}