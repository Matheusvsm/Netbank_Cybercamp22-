using System.Net;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Util.Resources.InternalTransferMsg;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRepository = Osb.Core.Platform.Integration.Repository.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.Models;
using NotificationMapping = Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Business.Util;

namespace Osb.Core.Platform.Business.Service
{
    public class InternalTransferService : IInternalTransferService
    {
        private readonly InternalTransferValidator _validator;
        private readonly InternalTransferMapper _mapper;
        private readonly IInternalTransferRepositoryFactory _internalTransferRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly IInternalTransferServiceFactory _internalTransferIntegrationServiceFactory;
        private readonly IFavoredRepositoryFactory _favoredRepositoryFactory;
        private readonly Settings _settings;
        private readonly IOperationRepositoryFactory _operationRepositoryFactory;
        private readonly IOperationAttachmentRepositoryFactory _operationAttachmentRepositoryFactory;
        private readonly IOperationTagRepositoryFactory _operationTagRepositoryFactory;
        private IConnectionFactory _connectionFactory;
        private readonly INotificationServiceFactory _notificationServiceFactory;
        private readonly INotificationService _notificationService;
        private readonly NotificationMapping.NotificationMapper _notificationMapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationRepositoryFactory _notificationRepositoryFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;

        public InternalTransferService(
            IInternalTransferRepositoryFactory internalTransferRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IOperationRepositoryFactory operationRepositoryFactory,
            IOperationAttachmentRepositoryFactory operationAttachmentRepositoryFactory,
            IOperationTagRepositoryFactory operationTagRepositoryFactory,
            IInternalTransferServiceFactory internalTransferIntegrationServiceFactory,
            IFavoredRepositoryFactory favoredRepositoryFactory,
            Settings settings,
            IConnectionFactory connectionFactory,
            INotificationService notificationService,
            INotificationServiceFactory notificationServiceFactory,
            INotificationRepository notificationRepository,
            INotificationRepositoryFactory notificationRepositoryFactory,
            IUserRepositoryFactory userRepositoryFactory
        )
        {
            _internalTransferRepositoryFactory = internalTransferRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _internalTransferIntegrationServiceFactory = internalTransferIntegrationServiceFactory;
            _favoredRepositoryFactory = favoredRepositoryFactory;
            _operationRepositoryFactory = operationRepositoryFactory;
            _operationAttachmentRepositoryFactory = operationAttachmentRepositoryFactory;
            _operationTagRepositoryFactory = operationTagRepositoryFactory;
            _mapper = new InternalTransferMapper();
            _validator = new InternalTransferValidator();
            _settings = settings;
            _connectionFactory = connectionFactory;
            _notificationService = notificationService;
            _notificationServiceFactory = notificationServiceFactory;
            _notificationMapper = new NotificationMapping.NotificationMapper();
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _notificationRepository = notificationRepository;
            _userRepositoryFactory = userRepositoryFactory;
        }

        public OperationResult Save(InternalTransferRequest internalTransferRequest)
        {
            _validator.Validate(internalTransferRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                Account fromAccount = accountRepository.GetById(internalTransferRequest.AccountId);
                Account toAccount;

                if (fromAccount == null)
                    throw new OsbBusinessException(InternalTransferExcMsg.EXC0010);

                if (string.IsNullOrEmpty(internalTransferRequest.AccountKey))
                    toAccount = accountRepository.GetByTaxId(internalTransferRequest.ToTaxId,
                                                            internalTransferRequest.Bank,
                                                            internalTransferRequest.BankBranch,
                                                            internalTransferRequest.BankAccount,
                                                            internalTransferRequest.BankAccountDigit);

                else
                    toAccount = accountRepository.GetByAccountKey(internalTransferRequest.AccountKey);

                if (toAccount == null)
                    throw new OsbBusinessException(InternalTransferExcMsg.EXC0011);

                if (fromAccount.AccountId == toAccount.AccountId)
                    throw new OsbBusinessException(InternalTransferExcMsg.EXC0012);

                if (fromAccount.CompanyId != toAccount.CompanyId)
                    throw new OsbBusinessException(InternalTransferExcMsg.EXC0013);

                IFavoredRepository favoredRepository = _favoredRepositoryFactory.Create();
                Favored favored = favoredRepository.GetFavored(fromAccount.AccountId, toAccount.TaxId,
                                                                                internalTransferRequest.Bank,
                                                                                internalTransferRequest.BankBranch,
                                                                                internalTransferRequest.BankAccount,
                                                                                internalTransferRequest.BankAccountDigit,
                                                                                OperationType.InternalTransfer
                );

                if (favored == null)
                {
                    favored = Favored.Create(internalTransferRequest.UserId, fromAccount.AccountId,
                                                       toAccount.TaxId, toAccount.Name,
                                                       OperationType.InternalTransfer, null,
                                                       toAccount.Bank, toAccount.BankBranch,
                                                       toAccount.BankAccount, toAccount.BankAccountDigit
                       );
                    favoredRepository.Save(favored, transactionScope);
                }

                Operation operation = Operation.Create(internalTransferRequest.UserId, OperationType.InternalTransfer);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                if (internalTransferRequest.Tags != null)
                {
                    IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();

                    foreach (string tag in internalTransferRequest.Tags)
                    {
                        OperationTag operationTag = OperationTag.Create(operation.OperationId, tag, internalTransferRequest.UserId);
                        operationTagRepository.Save(operationTag, transactionScope);
                    }
                }

                if (internalTransferRequest.Attachments != null)
                {
                    IOperationAttachmentRepository operationAttachmentRepository = _operationAttachmentRepositoryFactory.Create();
                    AttachmentManagement attachmentManagement = new AttachmentManagement();

                    foreach (Attachment attachment in internalTransferRequest.Attachments)
                    {
                        OperationAttachment operationAttachment = OperationAttachment.Create(
                            attachment.Content,
                            attachment.Extension,
                            operation.OperationId,
                            internalTransferRequest.UserId
                        );

                        attachmentManagement.SaveAttachment($"{_settings.FilePath}{operationAttachment.Name}-{operation.OperationId.ToString()}".ToLower(), attachment.Content);
                        operationAttachmentRepository.Save(operationAttachment, transactionScope);
                    }
                }

                InternalTransfer internalTransfer = InternalTransfer.Create(fromAccount.AccountId,
                                                                            toAccount.AccountId,
                                                                            internalTransferRequest.TransferValue,
                                                                            internalTransferRequest.TransferDate,
                                                                            internalTransferRequest.Description,
                                                                            operation.OperationId,
                                                                            internalTransferRequest.UserId);

                IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
                internalTransferRepository.Save(internalTransfer, transactionScope);

                transactionScope.Transaction.Commit();

                OperationResult operationResult = _mapper.Map(operation);

                return operationResult;
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

        public void GenerateInternalTransfer(InternalTransfer internalTransfer)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();

            IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
            IEnumerable<OperationTag> operationTags = operationTagRepository.GetOperationTagsByOperationId(internalTransfer.OperationId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account fromAccount = accountRepository.GetById(internalTransfer.FromAccountId);
            Account toAccount = accountRepository.GetById(internalTransfer.ToAccountId);

            IntegrationRequest.InternalTransferRequest integrationRequest = _mapper.Map(fromAccount, toAccount, internalTransfer, operationTags);

            IntegrationService.IInternalTransferService internalTransferIntergrationService = _internalTransferIntegrationServiceFactory.Create();
            IntegrationResponse.InternalTransferResponse internalTransferResponse = internalTransferIntergrationService.InternalTransfer(integrationRequest);

            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();

            IUserRepository userRepository = _userRepositoryFactory.Create();
            UserInformation userInformation = userRepository.GetByUserId(internalTransfer.CreationUserId);

            if (internalTransferResponse.ResponseStatus)
            {
                internalTransfer.Status = InternalTransferStatus.Generated;
                internalTransfer.ExternalIdentifier = internalTransferResponse.ExternalIdentifier;
                internalTransfer.ResponseMessage = internalTransferResponse.Message;

                if (_settings.SuccessEmailNotification)
                    Notification.SendMail(fromAccount.CompanyId, userInformation, notificationRepository, InternalTransferInfoMsg.INFO0001, InternalTransferInfoMsg.INFO0002);

                if (_settings.SuccessSmsNotification)
                    Notification.SendSms(fromAccount.CompanyId, userInformation, notificationRepository, InternalTransferInfoMsg.INFO0002);

                if (_settings.SuccessPushNotification)
                    Notification.SendPush(fromAccount.CompanyId, internalTransfer.OperationId, userInformation, notificationRepository, InternalTransferInfoMsg.INFO0001, InternalTransferInfoMsg.INFO0002);
            }
            else
            {
                internalTransfer.Status = InternalTransferStatus.Error;
                internalTransfer.ResponseMessage = internalTransferResponse.Message;

                if (_settings.FailureEmailNotification)
                    Notification.SendMail(fromAccount.CompanyId, userInformation, notificationRepository, InternalTransferInfoMsg.INFO0001, string.Format(InternalTransferInfoMsg.INFO0003, internalTransferResponse.Message));

                if (_settings.FailureSmsNotification)
                    Notification.SendSms(fromAccount.CompanyId, userInformation, notificationRepository, string.Format(InternalTransferInfoMsg.INFO0003, internalTransferResponse.Message));

                if (_settings.FailurePushNotification)
                    Notification.SendPush(fromAccount.CompanyId, internalTransfer.OperationId, userInformation, notificationRepository, InternalTransferInfoMsg.INFO0001, string.Format(InternalTransferInfoMsg.INFO0003, internalTransferResponse.Message));
            }

            internalTransferRepository.Update(internalTransfer);
        }

        public IEnumerable<InternalTransfer> FindInternalTransferListByStatus(InternalTransferStatus status)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
            IEnumerable<InternalTransfer> internalTransferList = internalTransferRepository.GetByStatus(status);

            return internalTransferList;
        }

        public void Update(InternalTransfer internalTransfer)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();

            internalTransferRepository.Update(internalTransfer);
        }

        public void UpdateStatus(UpdateInternalTransferRequest updateInternalTransferRequest)
        {
            _validator.Validate(updateInternalTransferRequest);

            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
            InternalTransfer internalTransfer = new InternalTransfer();

            if (updateInternalTransferRequest.InternalTransferId != null)
                internalTransfer = internalTransferRepository.GetById(updateInternalTransferRequest.InternalTransferId.Value);
            else
                internalTransfer = internalTransferRepository.GetByExternalIdentifier(updateInternalTransferRequest.ExternalIdentifier.Value);

            internalTransfer.Status = updateInternalTransferRequest.Status;
            internalTransfer.UpdateUserId = updateInternalTransferRequest.UserId;

            if (updateInternalTransferRequest.Status == InternalTransferStatus.Paid || updateInternalTransferRequest.Status == InternalTransferStatus.Error)
            {
                INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
                PushNotification pushNotification = notificationRepository.GetByOperationId(internalTransfer.OperationId);

                if (pushNotification != null)
                {
                    internalTransfer.UpdateUserId = pushNotification.UserId;
                    pushNotification.Status = PushNotificationStatus.CanBeSent;

                    if (updateInternalTransferRequest.Status == InternalTransferStatus.Paid)
                        pushNotification.Body = string.Format(PushNotificationMsg.MSG_SUCCESS_0001, internalTransfer.TransferValue);
                    else if (updateInternalTransferRequest.Status == InternalTransferStatus.Error)
                        pushNotification.Body = string.Format(PushNotificationMsg.MSG_ERROR_0001, internalTransfer.TransferValue);

                    notificationRepository.Update(pushNotification);
                }
            }

            internalTransferRepository.Update(internalTransfer);
        }

        public FindPendingInternalTransferResult FindPendingInternalTransfer(FindPendingInternalTransferRequest findPendingInternalTransferRequest)
        {
            _validator.Validate(findPendingInternalTransferRequest);

            IntegrationRequest.FindPendingInternalTransferRequest integrationRequest = _mapper.Map(findPendingInternalTransferRequest);

            IntegrationService.IInternalTransferService internalTransferIntegrationService = _internalTransferIntegrationServiceFactory.Create();
            IntegrationResponse.FindPendingInternalTransferResponse findPendingInternalTransferResponse = internalTransferIntegrationService.FindPendingInternalTransfer(integrationRequest);

            FindPendingInternalTransferResult result = _mapper.Map(findPendingInternalTransferResponse);
            return result;
        }

        public OperationResult Save(PendingInternalTransferRequest pendingInternalTransferRequest)
        {
            _validator.Validate(pendingInternalTransferRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                Account fromAccount = accountRepository.GetById(pendingInternalTransferRequest.AccountId);
                if (fromAccount == null)
                    throw new OsbBusinessException(InternalTransferExcMsg.EXC0010);

                Operation operation = Operation.Create(pendingInternalTransferRequest.UserId, OperationType.PendingInternalTransfer);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();
                PendingInternalTransfer pendingInternalTransfer = PendingInternalTransfer.Create(pendingInternalTransferRequest.AccountId,
                                                                                                operation.OperationId,
                                                                                                pendingInternalTransferRequest.PhoneNumber,
                                                                                                pendingInternalTransferRequest.CountryCode,
                                                                                                pendingInternalTransferRequest.Value,
                                                                                                fromAccount.TaxId,
                                                                                                fromAccount.Bank,
                                                                                                fromAccount.BankBranch,
                                                                                                fromAccount.BankAccount,
                                                                                                fromAccount.BankAccountDigit,
                                                                                                pendingInternalTransferRequest.UserId
                                                                                                );
                internalTransferRepository.Save(pendingInternalTransfer, transactionScope);

                transactionScope.Transaction.Commit();

                OperationResult operationResult = _mapper.Map(operation);

                return operationResult;
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

        public void GeneratePendingInternalTransfer(PendingInternalTransfer pendingInternalTransfer)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();

            IntegrationRequest.PendingInternalTransferRequest integrationRequest = _mapper.Map(pendingInternalTransfer);
            IntegrationService.IInternalTransferService pendingInternalTransferIntegrationService = _internalTransferIntegrationServiceFactory.Create();

            IntegrationResponse.PendingInternalTransferResponse pendingInternalTransferResponse = pendingInternalTransferIntegrationService.GeneratePendingInternalTransfer(integrationRequest);

            if (pendingInternalTransferResponse.ResponseStatus)
            {
                pendingInternalTransfer.Status = PendingInternalTransferStatus.Generated;
                pendingInternalTransfer.ExternalIdentifier = pendingInternalTransferResponse.Payload.ExternalIdentifier;
            }
            else
            {
                pendingInternalTransfer.Attempts += 1;

                if (pendingInternalTransfer.Attempts >= _settings.Attempts)
                    pendingInternalTransfer.Status = PendingInternalTransferStatus.Error;
            }

            internalTransferRepository.Update(pendingInternalTransfer);
        }

        public IEnumerable<PendingInternalTransfer> FindPendingInternalTransferListByStatus(PendingInternalTransferStatus status)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();

            IEnumerable<PendingInternalTransfer> pendingInternalTransferList = internalTransferRepository.GetListByStatus(status);

            return pendingInternalTransferList;
        }

        public void Update(PendingInternalTransfer pendingInternalTransfer)
        {
            IInternalTransferRepository internalTransferRepository = _internalTransferRepositoryFactory.Create();

            internalTransferRepository.Update(pendingInternalTransfer);
        }
    }
}