using Osb.Core.Api.Application.Util;
using Osb.Core.Api.Application.Models.Request;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class CardMapper
    {

        public BusinessRequest.FindCardRequest Map(FindCardRequest findCardRequest)
        {
            return new BusinessRequest.FindCardRequest
            {
                IdentifierCard = findCardRequest.IdentifierCard,
                AccountId = findCardRequest.AccountId,
                UserId = findCardRequest.UserId
            };
        }

        public BusinessRequest.VerifyCardRequest Map(VerifyCardRequest verifyCardRequest, object companyId)
        {
            return new BusinessRequest.VerifyCardRequest
            {
                IdentifierCard = verifyCardRequest.IdentifierCard,
                TaxId = Formatter.RemoveMaskFromTaxId(verifyCardRequest.TaxId),
                PanLastDigits = verifyCardRequest.PanLastDigits,
                CompanyId = (long)companyId,
                UserId = verifyCardRequest.UserId
            };
        }

        public BusinessRequest.ChangePinCardRequest Map(ChangePinCardRequest changePinCardRequest)
        {
            return new BusinessRequest.ChangePinCardRequest
            {
                IdentifierCard = changePinCardRequest.IdentifierCard,
                UserId = changePinCardRequest.UserId,
                AccountId = changePinCardRequest.AccountId,
                CurrentPin = changePinCardRequest.CurrentPin,
                Pin = changePinCardRequest.Pin,
                ConfirmationPin = changePinCardRequest.ConfirmationPin

            };
        }

        public BusinessRequest.FindCardListRequest Map(FindCardListRequest findCardListRequest)
        {
            return new BusinessRequest.FindCardListRequest
            {
                AccountId = findCardListRequest.AccountId,
                UserId = findCardListRequest.UserId,
                TaxId = Formatter.RemoveMaskFromTaxId(findCardListRequest.TaxId)
            };
        }

        public BusinessRequest.ActivateCardRequest Map(ActivateCardRequest activateCardRequest)
        {
            return new BusinessRequest.ActivateCardRequest
            {
                AccountId = activateCardRequest.AccountId,
                UserId = activateCardRequest.UserId,
                IdentifierCard = activateCardRequest.IdentifierCard
            };
        }

        public BusinessRequest.InactivateAndReissueCardRequest Map(InactivateAndReissueCardRequest inactivateAndReissueCardRequest)
        {
            return new BusinessRequest.InactivateAndReissueCardRequest
            {
                AccountId = inactivateAndReissueCardRequest.AccountId,
                IdentifierCard = inactivateAndReissueCardRequest.IdentifierCard,
                Pin = inactivateAndReissueCardRequest.Pin,
                ReasonCode = inactivateAndReissueCardRequest.ReasonCode,
                CardDeliveryAddress = Map(inactivateAndReissueCardRequest.CardDeliveryAddress),
                UserId = inactivateAndReissueCardRequest.UserId
            };
        }

        public BusinessRequest.CardDeliveryAddressRequest Map(CardDeliveryAddressRequest cardDeliveryAddressRequest)
        {
            return new BusinessRequest.CardDeliveryAddressRequest
            {
                Street = cardDeliveryAddressRequest.Street,
                Number = cardDeliveryAddressRequest.Number,
                Complement = cardDeliveryAddressRequest.Complement,
                Reference = cardDeliveryAddressRequest.Reference,
                District = cardDeliveryAddressRequest.District,
                ZipCode = Formatter.MaskFromZipCode(cardDeliveryAddressRequest.ZipCode),
                City = cardDeliveryAddressRequest.City,
                State = cardDeliveryAddressRequest.State,
                Country = cardDeliveryAddressRequest.Country
            };
        }

        public BusinessRequest.BlockCardRequest Map(BlockCardRequest blockCardRequest)
        {
            return new BusinessRequest.BlockCardRequest
            {
                AccountId = blockCardRequest.AccountId,
                UserId = blockCardRequest.UserId,
                IdentifierCard = blockCardRequest.IdentifierCard,
                Pin = blockCardRequest.Pin
            };
        }

        public BusinessRequest.BindCardRequest Map(BindCardRequest bindCardRequest)
        {
            return new BusinessRequest.BindCardRequest
            {
                AccountId = bindCardRequest.AccountId,
                UserId = bindCardRequest.UserId,
                IdentifierCard = bindCardRequest.IdentifierCard,
                UsageType = bindCardRequest.UsageType,
                cardOwner = Map(bindCardRequest.cardOwner),
                cardHolder = Map(bindCardRequest.cardHolder),
                cardHolderContact = Map(bindCardRequest.cardHolderContact)
            };
        }

        public BusinessRequest.CardOwnerRequest Map(CardOwnerRequest cardOwnerRequest)
        {
            return new BusinessRequest.CardOwnerRequest
            {
                OwnerTaxId = Formatter.RemoveMaskFromTaxId(cardOwnerRequest.OwnerTaxId),
                FullName = cardOwnerRequest.FullName,
                Phone = cardOwnerRequest.Phone,
                Mail = cardOwnerRequest.Mail,
                Bank = cardOwnerRequest.Bank,
                BankBranch = cardOwnerRequest.BankBranch,
                BankAccount = cardOwnerRequest.BankAccount,
                BankAccountDigit = cardOwnerRequest.BankAccountDigit
            };
        }

        public BusinessRequest.CardHolderRequest Map(CardHolderRequest cardHolderRequest)
        {
            return new BusinessRequest.CardHolderRequest
            {
                HolderTaxId = Formatter.RemoveMaskFromTaxId(cardHolderRequest.HolderTaxId),
                Nationality = cardHolderRequest.Nationality,
                MotherName = cardHolderRequest.MotherName,
                Gender = cardHolderRequest.Gender,
                FullName = cardHolderRequest.FullName,
                BirthDate = cardHolderRequest.BirthDate,
                MaritalStatus = cardHolderRequest.MaritalStatus
            };
        }
        public BusinessRequest.CancelCardRequest Map(CancelCardRequest cancelCardRequest)
        {
            return new BusinessRequest.CancelCardRequest
            {
                AccountId = cancelCardRequest.AccountId,
                UserId = cancelCardRequest.UserId,
                IdentifierCard = cancelCardRequest.IdentifierCard
            };
        }
        public BusinessRequest.CardHolderContactRequest Map(CardHolderContactRequest cardHolderContactRequest)
        {
            return new BusinessRequest.CardHolderContactRequest
            {
                Mail = cardHolderContactRequest.Mail,
                Phone = cardHolderContactRequest.Phone
            };
        }

        public BusinessRequest.UnblockCardRequest Map(UnblockCardRequest unblockCardRequest)
        {
            return new BusinessRequest.UnblockCardRequest
            {
                AccountId = unblockCardRequest.AccountId,
                UserId = unblockCardRequest.UserId,
                IdentifierCard = unblockCardRequest.IdentifierCard,
                Pin = unblockCardRequest.Pin
            };
        }
    }
}