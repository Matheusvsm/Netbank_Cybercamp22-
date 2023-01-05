using System;
using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Business.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly IDbContext<ActivateCard> _activateCardContext;
        private readonly IDbContext<BindCard> _bindCardContext;
        private readonly IDbContext<CardOwner> _cardOwnerContext;
        private readonly IDbContext<CardHolder> _cardHolderContext;
        private readonly IDbContext<CardHolderContact> _cardHolderContactContext;
        private readonly IDbContext<BlockCard> _blockCardContext;
        private readonly IDbContext<InactivateCard> _inactivateCardContext;
        private readonly IDbContext<ChangePinCard> _changePinCardContext;
        private readonly IDbContext<UnblockCard> _unblockContext;
        private readonly IDbContext<CancelCard> _cancelCardContext;

        public CardRepository(IDbContext<ActivateCard> activateCardContext, IDbContext<BindCard> bindCardContext, IDbContext<CardOwner> cardOwnerContext,
        IDbContext<CardHolder> cardHolderContext, IDbContext<CardHolderContact> cardHolderContactContext, IDbContext<BlockCard> blockCardContext,
        IDbContext<InactivateCard> inactivateCardContext, IDbContext<ChangePinCard> changePinCardContext, IDbContext<UnblockCard> unblockContext, IDbContext<CancelCard> cancelCardContext)
        {
            this._activateCardContext = activateCardContext;
            this._bindCardContext = bindCardContext;
            this._cardOwnerContext = cardOwnerContext;
            this._cardHolderContext = cardHolderContext;
            this._cardHolderContactContext = cardHolderContactContext;
            this._blockCardContext = blockCardContext;
            this._inactivateCardContext = inactivateCardContext;
            this._changePinCardContext = changePinCardContext;
            this._unblockContext = unblockContext;
            this._cancelCardContext = cancelCardContext;
        }

        public ActivateCard Save(ActivateCard activateCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = activateCard.Status,
                ["paramIdentifierCard"] = activateCard.IdentifierCard,
                ["paramAccountId"] = activateCard.AccountId,
                ["paramOperationId"] = activateCard.OperationId,
                ["paramUserId"] = activateCard.CreationUserId
            };

            ActivateCard result = _activateCardContext.ExecuteWithSingleResult("InsertActivateCard", parameters, transactionScope);

            return result;
        }

        public void Update(ActivateCard activateCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramActivateCardId"] = activateCard.ActivateCardId,
                ["paramStatus"] = activateCard.Status
            };

            _activateCardContext.ExecuteWithNoResult("UpdateActivateCard", parameters, transactionScope);
        }

        public BindCard Save(BindCard bindCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = bindCard.AccountId,
                ["paramOperationId"] = bindCard.OperationId,
                ["paramCardOwnerId"] = bindCard.CardOwnerId,
                ["paramCardHolderId"] = bindCard.CardHolderId,
                ["paramCardHolderContactId"] = bindCard.CardHolderContactId,
                ["paramIdentifierCard"] = bindCard.IdentifierCard,
                ["paramUsageType"] = bindCard.UsageType,
                ["paramOperationId"] = bindCard.OperationId,
                ["paramUserId"] = bindCard.CreationUserId,
            };

            BindCard result = _bindCardContext.ExecuteWithSingleResult("InsertBindCard", parameters, transactionScope);
            return result;
        }

        public void Update(BindCard bindCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramBindCardId"] = bindCard.BindCardId,
                ["paramStatus"] = bindCard.Status
            };

            _bindCardContext.ExecuteWithNoResult("UpdateBindCard", parameters, transactionScope);
        }

        public CardOwner Save(CardOwner cardOwner, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramOwnerTaxId"] = cardOwner.OwnerTaxId,
                ["paramFullName"] = cardOwner.FullName,
                ["paramPhone"] = cardOwner.Phone,
                ["paramMail"] = cardOwner.Mail,
                ["paramBank"] = cardOwner.Bank,
                ["paramBankBranch"] = cardOwner.BankBranch,
                ["paramBankAccount"] = cardOwner.BankAccount,
                ["paramBankAccountDigit"] = cardOwner.BankAccountDigit,
                ["paramCreationUserId"] = cardOwner.CreationUserId,
                ["paramUpdateUserId"] = cardOwner.UpdateUserId
            };

            CardOwner cardOwnerResult = _cardOwnerContext.ExecuteWithSingleResult("InsertCardOwner", parameters, transactionScope);
            return cardOwnerResult;
        }

        public CardHolder Save(CardHolder cardHolder, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramHolderTaxId"] = cardHolder.HolderTaxId,
                ["paramNationality"] = cardHolder.Nationality,
                ["paramMotherName"] = cardHolder.MotherName,
                ["paramGender"] = cardHolder.Gender,
                ["paramFullName"] = cardHolder.FullName,
                ["paramBirthDate"] = cardHolder.BirthDate,
                ["paramMaritalStatus"] = cardHolder.MaritalStatus,
                ["paramCreationUserId"] = cardHolder.CreationUserId,
                ["paramUpdateUserId"] = cardHolder.UpdateUserId
            };

            CardHolder cardHolderResult = _cardHolderContext.ExecuteWithSingleResult("InsertCardHolder", parameters, transactionScope);
            return cardHolderResult;
        }

        public CardHolderContact Save(CardHolderContact cardHolderContact, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramPhone"] = cardHolderContact.Phone,
                ["paramMail"] = cardHolderContact.Mail,
                ["paramCreationUserId"] = cardHolderContact.CreationUserId,
                ["paramUpdateUserId"] = cardHolderContact.UpdateUserId
            };

            CardHolderContact cardHolderContactResult = _cardHolderContactContext.ExecuteWithSingleResult("insertCardHolderContact", parameters, transactionScope);
            return cardHolderContactResult;
        }

        public BlockCard Save(BlockCard blockCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramIdentifierCard"] = blockCard.IdentifierCard,
                ["paramAccountId"] = blockCard.AccountId,
                ["paramPin"] = blockCard.Pin,
                ["paramSalt"] = blockCard.Salt,
                ["paramReasonCode"] = blockCard.ReasonCode,
                ["paramOperationId"] = blockCard.OperationId,
                ["paramUserId"] = blockCard.CreationUserId,
            };

            BlockCard result = _blockCardContext.ExecuteWithSingleResult("InsertBlockCard", parameters, transactionScope);
            return result;
        }

        public void Update(BlockCard blockCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramBlockCardId"] = blockCard.BlockCardId,
                ["paramStatus"] = blockCard.Status
            };

            _blockCardContext.ExecuteWithNoResult("UpdateBlockCard", parameters, transactionScope);
        }

        public UnblockCard Save(UnblockCard unblockCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramIdentifierCard"] = unblockCard.IdentifierCard,
                ["paramAccountId"] = unblockCard.AccountId,
                ["paramPin"] = unblockCard.Pin,
                ["paramSalt"] = unblockCard.Salt,
                ["paramOperationId"] = unblockCard.OperationId,
                ["paramUserId"] = unblockCard.CreationUserId,
            };

            UnblockCard result = _unblockContext.ExecuteWithSingleResult("InsertUnblockCard", parameters, transactionScope);
            return result;
        }

        public void Update(UnblockCard unblockCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUnblockCardId"] = unblockCard.UnblockCardId,
                ["paramStatus"] = unblockCard.Status
            };

            _unblockContext.ExecuteWithNoResult("UpdateUnblockCard", parameters, transactionScope);
        }

        public InactivateCard Save(InactivateCard inactivateCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramIdentifierCard"] = inactivateCard.IdentifierCard,
                ["paramAccountId"] = inactivateCard.AccountId,
                ["paramOperationId"] = inactivateCard.OperationId,
                ["paramPin"] = inactivateCard.Pin,
                ["paramSalt"] = inactivateCard.Salt,
                ["paramStatus"] = inactivateCard.Status,
                ["paramReasonCode"] = Convert.ChangeType(inactivateCard.ReasonCode, inactivateCard.ReasonCode.GetTypeCode()),
                ["paramUserId"] = inactivateCard.UpdateUserId
            };

            InactivateCard result = _inactivateCardContext.ExecuteWithSingleResult("InsertInactivateCard", parameters, transactionScope);
            return result;
        }

        public void Update(InactivateCard inactivateCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramInactivateCardId"] = inactivateCard.InactivateCardId,
                ["paramStatus"] = inactivateCard.Status
            };

            _inactivateCardContext.ExecuteWithNoResult("UpdateInactivateCard", parameters, transactionScope);
        }

        public ChangePinCard Save(ChangePinCard changePinCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramIdentifierCard"] = changePinCard.IdentifierCard,
                ["paramAccountId"] = changePinCard.AccountId,
                ["paramOperationId"] = changePinCard.OperationId,
                ["paramCurrentPin"] = changePinCard.CurrentPin,
                ["paramPin"] = changePinCard.Pin,
                ["paramConfirmationPin"] = changePinCard.ConfirmationPin,
                ["paramStatus"] = changePinCard.Status,
                ["paramSalt"] = changePinCard.Salt,
                ["paramUserId"] = changePinCard.CreationUserId
            };

            ChangePinCard result = _changePinCardContext.ExecuteWithSingleResult("InsertChangePinCard", parameters, transactionScope);
            return result;
        }

        public void Update(ChangePinCard changePinCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramChangePinCardId"] = changePinCard.ChangePinCardId,
                ["paramStatus"] = changePinCard.Status
            };

            _changePinCardContext.ExecuteWithNoResult("UpdateChangePinCard", parameters, transactionScope);
        }

        public CancelCard Save(CancelCard cancelCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = cancelCard.Status,
                ["paramIdentifierCard"] = cancelCard.IdentifierCard,
                ["paramAccountId"] = cancelCard.AccountId,
                ["paramOperationId"] = cancelCard.OperationId,
                ["paramUserId"] = cancelCard.CreationUserId
            };

            CancelCard result = _cancelCardContext.ExecuteWithSingleResult("InsertCancelCard", parameters, transactionScope);
            return result;
        }

        public void Update(CancelCard cancelCard, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCancelCardId"] = cancelCard.CancelCardId,
                ["paramStatus"] = cancelCard.Status
            };

            _cancelCardContext.ExecuteWithNoResult("UpdateCancelCard", parameters, transactionScope);
        }
    }
}