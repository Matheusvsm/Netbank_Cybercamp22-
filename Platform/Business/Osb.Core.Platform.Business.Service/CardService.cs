using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Util.Resources.CardExcMsg;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service
{
    public class CardService : ICardService
    {
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly CardValidator _validator;
        private readonly CardMapper _mapper;
        private readonly ICardRepositoryFactory _cardRepositoryFactory;
        private readonly ICardServiceFactory _cardIntegrationServiceFactory;
        private readonly IOperationRepositoryFactory _operationRepositoryFactory;
        private IConnectionFactory _connectionFactory;
        private readonly Settings _settings;

        public CardService(
            IAccountRepositoryFactory accountRepositoryFactory,
            ICardRepositoryFactory cardRepositoryFactory,
            ICardServiceFactory cardIntegrationServiceFactory,
            ICardServiceFactory cardServiceFactory,
            IOperationRepositoryFactory operationRepositoryFactory,
            Settings settings,
            IConnectionFactory connectionFactory
        )
        {
            _accountRepositoryFactory = accountRepositoryFactory;
            _cardRepositoryFactory = cardRepositoryFactory;
            _cardIntegrationServiceFactory = cardIntegrationServiceFactory;
            _operationRepositoryFactory = operationRepositoryFactory;
            _mapper = new CardMapper();
            _validator = new CardValidator();
            _settings = settings;
            _connectionFactory = connectionFactory;
        }

        public FindCardResult FindCard(FindCardRequest findCardRequest)
        {
            _validator.Validate(findCardRequest);

            IntegrationRequest.FindCardRequest integrationRequest = _mapper.Map(findCardRequest);

            IntegrationService.ICardService cardIntegrationService = _cardIntegrationServiceFactory.Create();
            IntegrationResponse.FindCardResponse findCardResponse = cardIntegrationService.FindCard(integrationRequest);

            FindCardResult result = _mapper.Map(findCardResponse);

            return result;
        }

        public FindCardListResult FindCardList(FindCardListRequest findCardListRequest)
        {
            _validator.Validate(findCardListRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(findCardListRequest.AccountId);

            if (account == null || account.TaxId != findCardListRequest.TaxId)
                throw new OsbBusinessException(string.Format(CardExcMsg.EXC0021));

            IntegrationRequest.FindCardListRequest integrationRequest = _mapper.Map(account);

            IntegrationService.ICardService cardIntergrationService = _cardIntegrationServiceFactory.Create();
            IntegrationResponse.FindCardListResponse findCardListResponse = cardIntergrationService.FindCardList(integrationRequest);

            FindCardListResult result = _mapper.Map(findCardListResponse.Cards);

            return result;
        }

        public bool VerifyCard(VerifyCardRequest verifyCardRequest)
        {
            _validator.Validate(verifyCardRequest);

            IntegrationRequest.FindCardRequest integrationRequest = _mapper.Map(verifyCardRequest);

            IntegrationService.ICardService cardIntegrationService = _cardIntegrationServiceFactory.Create();
            IntegrationResponse.FindCardResponse findCardResponse = cardIntegrationService.FindCard(integrationRequest);

            if (!findCardResponse.ResponseStatus || !(findCardResponse.PanLastDigits == verifyCardRequest.PanLastDigits && !string.IsNullOrEmpty(findCardResponse.CardHolderTaxId) && findCardResponse.CardHolderTaxId == verifyCardRequest.TaxId))
                return false;

            return true;
        }

        public CardResult Activate(ActivateCardRequest activateCardRequest)
        {
            _validator.Validate(activateCardRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(activateCardRequest.UserId, OperationType.ActivateCard);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                ICardRepository cardRepository = _cardRepositoryFactory.Create();

                ActivateCard activateCard = ActivateCard.Create(
                                                                activateCardRequest.AccountId,
                                                                activateCardRequest.UserId,
                                                                operation.OperationId,
                                                                activateCardRequest.IdentifierCard
                                                                );

                ActivateCard activateCardResult = cardRepository.Save(activateCard, transactionScope);

                IntegrationRequest.ActivateCardRequest integrationRequest = _mapper.Map(activateCard);

                IntegrationService.ICardService cardIntegrationService = _cardIntegrationServiceFactory.Create();
                IntegrationResponse.ActivateCardResponse activateCardResponse = cardIntegrationService.Activate(integrationRequest);

                if (activateCardResponse.ResponseStatus)
                    activateCardResult.Status = ActivateCardStatus.Activated;
                else
                    activateCardResult.Status = ActivateCardStatus.Error;

                cardRepository.Update(activateCardResult, transactionScope);

                transactionScope.Transaction.Commit();

                CardResult result = _mapper.Map(activateCardResponse);

                return result;
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public CardResult Block(BlockCardRequest blockCardRequest)
        {
            _validator.Validate(blockCardRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(blockCardRequest.UserId, OperationType.BlockCard);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                BlockCard blockCard = BlockCard.Create(
                    blockCardRequest.UserId,
                    blockCardRequest.AccountId,
                    blockCardRequest.IdentifierCard,
                    blockCardRequest.Pin,
                    operation.OperationId
                );

                blockCard = _mapper.MapEncrypted(blockCard, _settings.AesIV, _settings.AesKey);

                ICardRepository cardRepository = _cardRepositoryFactory.Create();
                BlockCard blockCardResult = cardRepository.Save(blockCard, transactionScope);

                IntegrationService.ICardService blockCardIntergrationService = _cardIntegrationServiceFactory.Create();
                IntegrationRequest.BlockCardRequest integrationRequest = _mapper.Map(blockCard, _settings.AesIV, _settings.AesKey);
                IntegrationResponse.BlockCardResponse blockCardResponse = blockCardIntergrationService.Block(integrationRequest);

                if (blockCardResponse.ResponseStatus)
                    blockCardResult.Status = BlockCardStatus.Blocked;
                else
                    blockCardResult.Status = BlockCardStatus.Error;

                cardRepository.Update(blockCardResult, transactionScope);

                transactionScope.Transaction.Commit();

                CardResult result = _mapper.Map(blockCardResponse);

                return result;
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public CardResult Unblock(UnblockCardRequest unblockCardRequest)
        {
            _validator.Validate(unblockCardRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(unblockCardRequest.UserId, OperationType.BlockCard);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                UnblockCard unblockCard = UnblockCard.Create(
                    unblockCardRequest.UserId,
                    unblockCardRequest.AccountId,
                    unblockCardRequest.IdentifierCard,
                    unblockCardRequest.Pin,
                    operation.OperationId
                );

                UnblockCard encryptedUnblockCard = _mapper.MapEncrypted(unblockCard, _settings.AesIV, _settings.AesKey);

                ICardRepository unblockCardRepository = _cardRepositoryFactory.Create();
                unblockCard = unblockCardRepository.Save(encryptedUnblockCard, transactionScope);

                IntegrationService.ICardService unblockCardIntergrationService = _cardIntegrationServiceFactory.Create();
                IntegrationRequest.UnblockCardRequest integrationRequest = _mapper.Map(encryptedUnblockCard, _settings.AesIV, _settings.AesKey);
                IntegrationResponse.UnblockCardResponse unblockCardResponse = unblockCardIntergrationService.Unblock(integrationRequest);

                if (unblockCardResponse.ResponseStatus)
                    unblockCard.Status = UnblockCardStatus.Unblocked;
                else
                    unblockCard.Status = UnblockCardStatus.Error;

                unblockCardRepository.Update(unblockCard, transactionScope);

                transactionScope.Transaction.Commit();

                CardResult result = _mapper.Map(unblockCardResponse);

                return result;
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public CardResult ChangePin(ChangePinCardRequest changePinCardRequest)
        {
            _validator.Validate(changePinCardRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(changePinCardRequest.UserId, OperationType.ChangePinCard);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                ChangePinCard changePinCard = ChangePinCard.Create(
                    changePinCardRequest.IdentifierCard,
                    changePinCardRequest.UserId,
                    operation.OperationId,
                    changePinCardRequest.AccountId,
                    changePinCardRequest.CurrentPin,
                    changePinCardRequest.Pin,
                    changePinCardRequest.ConfirmationPin
                    );

                ChangePinCard encryptedChangePinCard = _mapper.MapEncrypted(changePinCard, _settings.AesIV, _settings.AesKey);

                ICardRepository cardRepository = _cardRepositoryFactory.Create();
                changePinCard = cardRepository.Save(encryptedChangePinCard, transactionScope);

                IntegrationService.ICardService cardService = _cardIntegrationServiceFactory.Create();
                IntegrationRequest.ChangePinCardRequest integrationRequest = _mapper.Map(encryptedChangePinCard, _settings.AesIV, _settings.AesKey);

                IntegrationResponse.ChangePinCardResponse changePinCardResponse = cardService.ChangePin(integrationRequest);

                if (changePinCardResponse.ResponseStatus)
                    changePinCard.Status = ChangePinCardStatus.Changed;
                else
                    changePinCard.Status = ChangePinCardStatus.Error;

                cardRepository.Update(changePinCard, transactionScope);

                transactionScope.Transaction.Commit();

                CardResult result = _mapper.Map(changePinCardResponse);

                return result;
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public CardResult BindUnnamedCard(BindCardRequest bindCardRequest)
        {
            _validator.Validate(bindCardRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                ICardRepository cardRepository = _cardRepositoryFactory.Create();

                CardOwner cardOwner = CardOwner.Create(bindCardRequest.UserId,
                                                        bindCardRequest.cardOwner.OwnerTaxId,
                                                        bindCardRequest.cardOwner.FullName,
                                                        bindCardRequest.cardOwner.Phone,
                                                        bindCardRequest.cardOwner.Mail,
                                                        bindCardRequest.cardOwner.Bank,
                                                        bindCardRequest.cardOwner.BankBranch,
                                                        bindCardRequest.cardOwner.BankAccount,
                                                        bindCardRequest.cardOwner.BankAccountDigit
                                                        );
                CardOwner cardOwnerId = cardRepository.Save(cardOwner, transactionScope);

                CardHolder cardHolder = CardHolder.Create(bindCardRequest.UserId,
                                                            bindCardRequest.cardHolder.HolderTaxId,
                                                            bindCardRequest.cardHolder.Nationality,
                                                            bindCardRequest.cardHolder.MotherName,
                                                            bindCardRequest.cardHolder.Gender,
                                                            bindCardRequest.cardHolder.FullName,
                                                            bindCardRequest.cardHolder.BirthDate,
                                                            bindCardRequest.cardHolder.MaritalStatus
                                                            );
                CardHolder cardHolderId = cardRepository.Save(cardHolder, transactionScope);

                CardHolderContact cardHolderContact = CardHolderContact.Create(bindCardRequest.UserId,
                                                                bindCardRequest.cardHolderContact.Phone,
                                                                bindCardRequest.cardHolderContact.Mail
                                                                );
                CardHolderContact cardHolderContactId = cardRepository.Save(cardHolderContact, transactionScope);

                Operation operation = Operation.Create(bindCardRequest.UserId, OperationType.BindCard);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                BindCard bindCard = BindCard.Create(bindCardRequest.AccountId,
                                                    operation.OperationId,
                                                    cardOwnerId.CardOwnerId,
                                                    cardHolderId.CardHolderId,
                                                    cardHolderContactId.CardHolderContactId,
                                                    bindCardRequest.IdentifierCard,
                                                    bindCardRequest.UsageType,
                                                    bindCardRequest.UserId
                                                    );
                BindCard bindCardResult = cardRepository.Save(bindCard, transactionScope);

                IntegrationRequest.BindUnnamedCardRequest integrationRequest = _mapper.Map(bindCard, cardOwner, cardHolder, cardHolderContact);

                IntegrationService.ICardService cardIntegrationService = _cardIntegrationServiceFactory.Create();
                IntegrationResponse.BindUnnamedCardResponse bindCardResponse = cardIntegrationService.BindUnnamedCard(integrationRequest);

                if (bindCardResponse.ResponseStatus)
                    bindCardResult.Status = BindCardStatus.Binded;
                else
                    bindCardResult.Status = BindCardStatus.Error;

                cardRepository.Update(bindCardResult, transactionScope);

                transactionScope.Transaction.Commit();

                CardResult result = _mapper.Map(bindCardResponse);

                return result;
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public CardResult InactivateAndReissue(InactivateAndReissueCardRequest inactivateAndReissueCardRequest)
        {
            _validator.Validate(inactivateAndReissueCardRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(inactivateAndReissueCardRequest.UserId, OperationType.InactivateAndReissueCard);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                InactivateCard inactivateCard = InactivateCard.Create
                (
                    inactivateAndReissueCardRequest.IdentifierCard,
                    inactivateAndReissueCardRequest.AccountId,
                    operation.OperationId,
                    inactivateAndReissueCardRequest.Pin,
                    inactivateAndReissueCardRequest.ReasonCode,
                    inactivateAndReissueCardRequest.UserId
                );

                InactivateCard encryptedInactivateCard = _mapper.MapEncrypted(inactivateCard, _settings.AesIV, _settings.AesKey);

                ICardRepository cardRepository = _cardRepositoryFactory.Create();
                inactivateCard = cardRepository.Save(encryptedInactivateCard, transactionScope);

                IntegrationService.ICardService cardIntegrationService = _cardIntegrationServiceFactory.Create();

                IntegrationRequest.InactivateAndReissueCardRequest integrationRequest = _mapper.Map(encryptedInactivateCard, _settings.AesIV, _settings.AesKey, inactivateAndReissueCardRequest);

                IntegrationResponse.InactivateAndReissueCardResponse inactivateAndReissueCardResponse = cardIntegrationService.InactivateAndReissueCard(integrationRequest);

                if (inactivateAndReissueCardResponse.ResponseStatus)
                    inactivateCard.Status = InactivateCardStatus.Inactivated;
                else
                    inactivateCard.Status = InactivateCardStatus.Error;

                cardRepository.Update(inactivateCard, transactionScope);

                transactionScope.Transaction.Commit();

                CardResult result = _mapper.Map(inactivateAndReissueCardResponse);

                return result;
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }

        public CardResult Cancel(CancelCardRequest cancelCardRequest)
        {
            _validator.Validate(cancelCardRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(cancelCardRequest.UserId, OperationType.CancelCard);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                CancelCard cancelCard = CancelCard.Create
                (
                    cancelCardRequest.AccountId,
                    cancelCardRequest.UserId,
                    cancelCardRequest.IdentifierCard,
                    operation.OperationId
                );

                ICardRepository cardRepository = _cardRepositoryFactory.Create();
                cardRepository.Save(cancelCard, transactionScope);

                IntegrationRequest.CancelCardRequest integrationRequest = _mapper.Map(cancelCard);

                IntegrationService.ICardService cardIntegrationService = _cardIntegrationServiceFactory.Create();
                IntegrationResponse.CancelCardResponse cancelCardResponse = cardIntegrationService.CancelCard(integrationRequest);

                if (cancelCardResponse.ResponseStatus)
                    cancelCard.Status = CancelCardStatus.Canceled;
                else
                    cancelCard.Status = CancelCardStatus.Error;

                cardRepository.Update(cancelCard);

                transactionScope.Transaction.Commit();

                CardResult result = _mapper.Map(cancelCardResponse);

                return result;
            }
            catch
            {
                transactionScope.Transaction.Rollback();
                throw;
            }
            finally
            {
                transactionScope.Connection.Close();
            }
        }
    }
}