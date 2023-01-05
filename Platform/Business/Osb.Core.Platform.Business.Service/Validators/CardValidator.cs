using System;
using System.Text.RegularExpressions;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.CardExcMsg;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class CardValidator
    {

        public void Validate(FindCardRequest cardRequest)
        {
            if (string.IsNullOrEmpty(cardRequest.IdentifierCard))
                throw new OsbBusinessException(CardExcMsg.EXC0001);
        }

        public void Validate(FindCardListRequest request)
        {
            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(CardExcMsg.EXC0002);
        }

        public void Validate(VerifyCardRequest cardRequest)
        {
            if (string.IsNullOrEmpty(cardRequest.IdentifierCard))
                throw new OsbBusinessException(CardExcMsg.EXC0001);

            if (string.IsNullOrEmpty(cardRequest.TaxId))
                throw new OsbBusinessException(CardExcMsg.EXC0003);

            if (string.IsNullOrEmpty(cardRequest.PanLastDigits))
                throw new OsbBusinessException(CardExcMsg.EXC0004);
        }

        public void Validate(ActivateCardRequest activateCardRequest)
        {
            if (string.IsNullOrEmpty(activateCardRequest.IdentifierCard))
                throw new OsbBusinessException(CardExcMsg.EXC0005);
        }


        public void Validate(CancelCardRequest cancelCardRequest)
        {
            if (string.IsNullOrEmpty(cancelCardRequest.IdentifierCard))
                throw new OsbBusinessException(CardExcMsg.EXC0005);
        }

        public void Validate(InactivateAndReissueCardRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(CardExcMsg.EXC0006);

            if (string.IsNullOrEmpty(request.IdentifierCard))
                throw new OsbBusinessException(CardExcMsg.EXC0007);

            if (string.IsNullOrEmpty(request.Pin))
                throw new OsbBusinessException(CardExcMsg.EXC0008);

            if (request.Pin.Length != 4)
                throw new OsbBusinessException(CardExcMsg.EXC0009);

            if (!Enum.IsDefined(typeof(CardReasonCode), request.ReasonCode))
                throw new OsbBusinessException(CardExcMsg.EXC0010);
                
            if (!Regex.IsMatch(request.CardDeliveryAddress.Number, "^[0-9]+$"))
                throw new OsbBusinessException(CardExcMsg.EXC0022);
            
            if (string.IsNullOrEmpty(request.CardDeliveryAddress.Street))
                throw new OsbBusinessException(CardExcMsg.EXC0023);
            
            if (string.IsNullOrEmpty(request.CardDeliveryAddress.District))
                throw new OsbBusinessException(CardExcMsg.EXC0024);

            if (string.IsNullOrEmpty(request.CardDeliveryAddress.ZipCode))
                throw new OsbBusinessException(CardExcMsg.EXC0025);

            if (string.IsNullOrEmpty(request.CardDeliveryAddress.City))
                throw new OsbBusinessException(CardExcMsg.EXC0026);
            
            if (string.IsNullOrEmpty(request.CardDeliveryAddress.State))
                throw new OsbBusinessException(CardExcMsg.EXC0027);
            
            if (string.IsNullOrEmpty(request.CardDeliveryAddress.Country))
                throw new OsbBusinessException(CardExcMsg.EXC0028);
        }

        public void Validate(BlockCardRequest blockCardRequest)
        {
            if (string.IsNullOrEmpty(blockCardRequest.IdentifierCard))
                throw new OsbBusinessException(string.Format(CardExcMsg.EXC0007));

            if (string.IsNullOrEmpty(blockCardRequest.Pin))
                throw new OsbBusinessException(string.Format(CardExcMsg.EXC0008));

            if (blockCardRequest.Pin.Length != 4)
                throw new OsbBusinessException(CardExcMsg.EXC0009);
        }

        public void Validate(UnblockCardRequest unblockCardRequest)
        {
            if (string.IsNullOrEmpty(unblockCardRequest.IdentifierCard))
                throw new OsbBusinessException(string.Format(CardExcMsg.EXC0007));

            if (string.IsNullOrEmpty(unblockCardRequest.Pin))
                throw new OsbBusinessException(string.Format(CardExcMsg.EXC0008));

            if (unblockCardRequest.Pin.Length != 4)
                throw new OsbBusinessException(CardExcMsg.EXC0009);

        }

        public void Validate(ChangePinCardRequest request)
        {
            if (string.IsNullOrEmpty(request.IdentifierCard))
                throw new OsbBusinessException(CardExcMsg.EXC0007);

            // if (string.IsNullOrEmpty(request.CurrentPin))
            //     throw new OsbBusinessException(BusinessExcMsg.EXC0090);

            if (string.IsNullOrEmpty(request.Pin))
                throw new OsbBusinessException(CardExcMsg.EXC0008);

            if (string.IsNullOrEmpty(request.ConfirmationPin))
                throw new OsbBusinessException(CardExcMsg.EXC0011);

            if (request.ConfirmationPin != request.Pin)
                throw new OsbBusinessException(CardExcMsg.EXC0012);
        }

        public void Validate(UpdateChangePinCardStatusRequest updateChangePinCardStatusRequest)
        {
            if (string.IsNullOrEmpty(updateChangePinCardStatusRequest.Identifier))
                throw new OsbBusinessException(CardExcMsg.EXC0007);

            if (!Enum.IsDefined(typeof(ChangePinCardStatus), updateChangePinCardStatusRequest.Status))
                throw new OsbBusinessException(CardExcMsg.EXC0013);
        }

        public void Validate(BindCardRequest bindCardRequest)
        {
            if (String.IsNullOrEmpty(bindCardRequest.IdentifierCard))
                throw new OsbBusinessException(CardExcMsg.EXC0005);

            if (String.IsNullOrEmpty(bindCardRequest.cardHolder.HolderTaxId))
                throw new OsbBusinessException(CardExcMsg.EXC0003);

            if (String.IsNullOrEmpty(bindCardRequest.cardHolder.Nationality))
                throw new OsbBusinessException(CardExcMsg.EXC0014);

            if (String.IsNullOrEmpty(bindCardRequest.cardHolder.MotherName))
                throw new OsbBusinessException(CardExcMsg.EXC0015);

            if (!Enum.IsDefined(typeof(Gender), bindCardRequest.cardHolder.Gender))
                throw new OsbBusinessException(CardExcMsg.EXC0016);

            if (String.IsNullOrEmpty(bindCardRequest.cardHolder.FullName))
                throw new OsbBusinessException(CardExcMsg.EXC0017);

            if (!Enum.IsDefined(typeof(MaritalStatus), bindCardRequest.cardHolder.MaritalStatus))
                throw new OsbBusinessException(CardExcMsg.EXC0018);

            if (String.IsNullOrEmpty(bindCardRequest.cardOwner.OwnerTaxId))
                throw new OsbBusinessException(CardExcMsg.EXC0003);

            if (String.IsNullOrEmpty(bindCardRequest.cardOwner.FullName))
                throw new OsbBusinessException(CardExcMsg.EXC0017);

            if (String.IsNullOrEmpty(bindCardRequest.cardOwner.Phone))
                throw new OsbBusinessException(CardExcMsg.EXC0019);

            if (String.IsNullOrEmpty(bindCardRequest.cardOwner.Mail))
                throw new OsbBusinessException(CardExcMsg.EXC0020);

            if (String.IsNullOrEmpty(bindCardRequest.cardHolderContact.Phone))
                throw new OsbBusinessException(CardExcMsg.EXC0019);

            if (String.IsNullOrEmpty(bindCardRequest.cardHolderContact.Mail))
                throw new OsbBusinessException(CardExcMsg.EXC0020);
        }
    }
}