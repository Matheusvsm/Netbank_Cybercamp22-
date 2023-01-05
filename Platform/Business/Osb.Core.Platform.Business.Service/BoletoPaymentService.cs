using System;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Common.Entity;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;
using NotificationMapping = Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Business.Util.Resources.BoletoPaymentMsg;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Business.Util;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Business.Service
{
    public class BoletoPaymentService : IBoletoPaymentService
    {
        private readonly BoletoPaymentValidator _validator;
        private readonly BoletoPaymentMapper _mapper;
        private readonly IBoletoPaymentServiceFactory _boletoPaymentIntegrationServiceFactory;
        private readonly IBoletoPaymentRepositoryFactory _boletoPaymentRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly IOperationRepositoryFactory _operationRepositoryFactory;
        private readonly IOperationAttachmentRepositoryFactory _operationAttachmentRepositoryFactory;
        private readonly IOperationTagRepositoryFactory _operationTagRepositoryFactory;
        private readonly Settings _settings;
        private IConnectionFactory _connectionFactory;
        private readonly INotificationServiceFactory _notificationServiceFactory;
        private readonly INotificationService _notificationService;
        private readonly NotificationMapping.NotificationMapper _notificationMapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationRepositoryFactory _notificationRepositoryFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;

        public BoletoPaymentService(
            IBoletoPaymentServiceFactory boletoPaymentIntegrationServiceFactory,
            IBoletoPaymentRepositoryFactory boletoPaymentRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IOperationRepositoryFactory operationRepositoryFactory,
            IOperationAttachmentRepositoryFactory operationAttachmentRepositoryFactory,
            IOperationTagRepositoryFactory operationTagRepositoryFactory,
            Settings settings,
            IConnectionFactory connectionFactory,
            INotificationServiceFactory notificationServiceFactory,
            INotificationService notificationService,
            INotificationRepository notificationRepository,
            INotificationRepositoryFactory notificationRepositoryFactory,
            IUserRepositoryFactory userRepositoryFactory
        )
        {
            _boletoPaymentIntegrationServiceFactory = boletoPaymentIntegrationServiceFactory;
            _boletoPaymentRepositoryFactory = boletoPaymentRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _operationRepositoryFactory = operationRepositoryFactory;
            _operationAttachmentRepositoryFactory = operationAttachmentRepositoryFactory;
            _operationTagRepositoryFactory = operationTagRepositoryFactory;
            _settings = settings;
            _mapper = new BoletoPaymentMapper();
            _connectionFactory = connectionFactory;
            _validator = new BoletoPaymentValidator();
            _notificationServiceFactory = notificationServiceFactory;
            _notificationService = notificationService;
            _notificationMapper = new NotificationMapping.NotificationMapper();
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _notificationRepository = notificationRepository;
            _userRepositoryFactory = userRepositoryFactory;
        }

        public OperationResult Save(BoletoPaymentRequest boletoPaymentRequest)
        {
            _validator.Validate(boletoPaymentRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();
            try
            {
                Operation operation = Operation.Create(boletoPaymentRequest.UserId, OperationType.BoletoPayment);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                if (boletoPaymentRequest.Tags != null)
                {
                    IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();

                    foreach (string tag in boletoPaymentRequest.Tags)
                    {
                        OperationTag operationTag = OperationTag.Create(operation.OperationId, tag, boletoPaymentRequest.UserId);
                        operationTagRepository.Save(operationTag, transactionScope);
                    }
                }

                if (boletoPaymentRequest.Attachments != null)
                {
                    IOperationAttachmentRepository operationAttachmentRepository = _operationAttachmentRepositoryFactory.Create();
                    AttachmentManagement attachmentManagement = new AttachmentManagement();

                    foreach (Attachment attachment in boletoPaymentRequest.Attachments)
                    {
                        OperationAttachment operationAttachment = OperationAttachment.Create(
                            attachment.Content,
                            attachment.Extension,
                            operation.OperationId,
                            boletoPaymentRequest.UserId
                        );

                        attachmentManagement.SaveAttachment($"{_settings.FilePath}{operationAttachment.Name}-{operation.OperationId.ToString()}".ToLower(), attachment.Content);
                        operationAttachmentRepository.Save(operationAttachment, transactionScope);
                    }
                }

                BoletoPayment boletoPayment = BoletoPayment.Create(boletoPaymentRequest.UserId,
                                                                    boletoPaymentRequest.AccountId,
                                                                    operation.OperationId,
                                                                    boletoPaymentRequest.Name,
                                                                    boletoPaymentRequest.TaxId,
                                                                    boletoPaymentRequest.ReceiverName,
                                                                    boletoPaymentRequest.ReceiverTaxId,
                                                                    boletoPaymentRequest.PayerName,
                                                                    boletoPaymentRequest.PayerTaxId,
                                                                    boletoPaymentRequest.Barcode,
                                                                    boletoPaymentRequest.PaymentValue,
                                                                    boletoPaymentRequest.PaymentDate,
                                                                    boletoPaymentRequest.DueDate,
                                                                    boletoPaymentRequest.DiscountValue,
                                                                    boletoPaymentRequest.Description,
                                                                    boletoPaymentRequest.Identifier
                                                                );

                IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
                boletoPaymentRepository.Save(boletoPayment, transactionScope);

                IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                Account account = accountRepository.GetById(boletoPaymentRequest.AccountId);

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

        public void GenerateBoletoPayment(BoletoPayment boletoPayment)
        {
            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(boletoPayment.AccountId);

            IntegrationRequest.BoletoPaymentRequest integrationRequest = _mapper.Map(boletoPayment, account);

            IntegrationService.IBoletoPaymentService boletoPaymentService = _boletoPaymentIntegrationServiceFactory.Create();
            IntegrationResponse.BoletoPaymentResponse boletoPaymentResponse = boletoPaymentService.GenerateBoletoPayment(integrationRequest);

            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
            IUserRepository userRepository = _userRepositoryFactory.Create();

            UserInformation userInformation = userRepository.GetByUserId(boletoPayment.CreationUserId);

            if (boletoPaymentResponse.ResponseStatus)
            {
                boletoPayment.Status = BoletoPaymentStatus.Generated;
                boletoPayment.ExternalIdentifier = boletoPaymentResponse.ExternalIdentifier;
                boletoPayment.ResponseMessage = boletoPaymentResponse.Message;

                if (_settings.SuccessEmailNotification)
                    Notification.SendMail(account.CompanyId, userInformation, notificationRepository, BoletoPaymentInfoMsg.INFO0001, BoletoPaymentInfoMsg.INFO0002);

                if (_settings.SuccessSmsNotification)
                    Notification.SendSms(account.CompanyId, userInformation, notificationRepository, BoletoPaymentInfoMsg.INFO0002);

                if (_settings.SuccessPushNotification)
                    Notification.SendPush(account.CompanyId, boletoPayment.OperationId, userInformation, notificationRepository, BoletoPaymentInfoMsg.INFO0001, BoletoPaymentInfoMsg.INFO0002);
            }
            else
            {
                boletoPayment.Status = BoletoPaymentStatus.Error;
                boletoPayment.ResponseMessage = boletoPaymentResponse.Message;

                if (_settings.FailureEmailNotification)
                    Notification.SendMail(account.CompanyId, userInformation, notificationRepository, BoletoPaymentInfoMsg.INFO0001, string.Format(BoletoPaymentInfoMsg.INFO0003, boletoPaymentResponse.Message));

                if (_settings.FailureSmsNotification)
                    Notification.SendSms(account.CompanyId, userInformation, notificationRepository, string.Format(BoletoPaymentInfoMsg.INFO0003, boletoPaymentResponse.Message));

                if (_settings.FailurePushNotification)
                    Notification.SendPush(account.CompanyId, boletoPayment.OperationId, userInformation, notificationRepository, BoletoPaymentInfoMsg.INFO0001, string.Format(BoletoPaymentInfoMsg.INFO0003, boletoPaymentResponse.Message));
            }

            IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
            boletoPaymentRepository.Update(boletoPayment);
        }

        public void UpdateBoletoPayment(BoletoPayment boletoPayment)
        {
            IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();

            boletoPaymentRepository.Update(boletoPayment);
        }

        public void UpdateBoletoPaymentStatus(UpdateBoletoPaymentStatusRequest updateBoletoPaymentStatusRequest)
        {
            IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
            BoletoPayment boletoPayment = new BoletoPayment();

            if (updateBoletoPaymentStatusRequest.ExternalIdentifier != null)
                boletoPayment = boletoPaymentRepository.GetByExternalIdentifier(updateBoletoPaymentStatusRequest.ExternalIdentifier.Value);

            boletoPayment.Status = updateBoletoPaymentStatusRequest.Status;

            if (updateBoletoPaymentStatusRequest.Status == BoletoPaymentStatus.Paid || updateBoletoPaymentStatusRequest.Status == BoletoPaymentStatus.Error)
            {
                INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
                PushNotification pushNotification = notificationRepository.GetByOperationId(boletoPayment.OperationId);

                if (pushNotification != null)
                {
                    boletoPayment.UpdateUserId = pushNotification.UserId;
                    pushNotification.Status = PushNotificationStatus.CanBeSent;

                    if (updateBoletoPaymentStatusRequest.Status == BoletoPaymentStatus.Paid)
                        pushNotification.Body = string.Format(PushNotificationMsg.MSG_SUCCESS_0002, boletoPayment.PaymentValue);
                    else if (updateBoletoPaymentStatusRequest.Status == BoletoPaymentStatus.Error)
                        pushNotification.Body = string.Format(PushNotificationMsg.MSG_ERROR_0002, boletoPayment.PaymentValue);

                    notificationRepository.Update(pushNotification);
                }
            }

            boletoPaymentRepository.Update(boletoPayment);
        }

        public IEnumerable<BoletoPayment> FindBoletoPaymentListByStatus(BoletoPaymentStatus status)
        {
            IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
            IEnumerable<BoletoPayment> boletoPaymentList = boletoPaymentRepository.GetListByStatus(status);

            return boletoPaymentList;
        }

        public FindBoletoInfoResult FindBoletoInfo(FindBoletoInfoRequest findBoletoInfoRequest)
        {
            _validator.Validate(findBoletoInfoRequest);

            IntegrationRequest.VerifyBoletoCanBePaidRequest verifyBoletoCanBePaidRequest = _mapper.MapVerifyCanBePaid(findBoletoInfoRequest);

            IntegrationService.IBoletoPaymentService paymentIntegrationService = _boletoPaymentIntegrationServiceFactory.Create();

            IntegrationResponse.VerifyBoletoCanBePaidResponse verifiyBoletoCanBePaidResponse = paymentIntegrationService.VerifyBoletoCanBePaid(verifyBoletoCanBePaidRequest);

            FindBoletoInfoResult findBoletoInfoResult = null;
            FindExpectedBoletoPaymentDateResult expectedBoletoPaymentDateResult = null;

            if (verifiyBoletoCanBePaidResponse.ResponseStatus && verifiyBoletoCanBePaidResponse.CanBePaid)
            {
                if ((findBoletoInfoRequest.NumericSequence.Length == 47 && findBoletoInfoRequest.BoletoType == BoletoType.Bank) || (findBoletoInfoRequest.BoletoType == BoletoType.Concessionare))
                {
                    IntegrationRequest.FindInfosPaymentByBarcodeRequest findInfosPaymentByBarcodeRequest = _mapper.MapBoletoInfo(findBoletoInfoRequest);
                    IntegrationResponse.FindInfosPaymentByBarcodeReponse findInfosPaymentByBarcodeResponse = paymentIntegrationService.FindInfosPaymentByBarcode(findInfosPaymentByBarcodeRequest);

                    if (findBoletoInfoRequest.BoletoType == BoletoType.Concessionare)
                    {
                        expectedBoletoPaymentDateResult = FindExpectedBoletoPaymentDate(new FindExpectedBoletoPaymentDateRequest { AccountId = findBoletoInfoRequest.AccountId, ActualDatePayment = DateTime.Now, BarCode = findInfosPaymentByBarcodeResponse.Barcode });
                        findInfosPaymentByBarcodeResponse.PaymentDate = expectedBoletoPaymentDateResult.ExpectedBoletoPaymentDate;

                        findBoletoInfoResult = _mapper.Map(findInfosPaymentByBarcodeResponse);

                        return findBoletoInfoResult;
                    }

                    findBoletoInfoRequest.NumericSequence = findInfosPaymentByBarcodeResponse.Barcode;
                }

                IntegrationRequest.FindInfosPaymentCIPByBarcodeRequest findInfosPaymentCIPByBarcodeRequest = _mapper.MapCIP(findBoletoInfoRequest);
                IntegrationResponse.FindInfosPaymentCIPByBarcodeResponse findInfosPaymentCIPByBarcodeResponse = paymentIntegrationService.FindInfosPaymentCIPByBarcode(findInfosPaymentCIPByBarcodeRequest);

                if (expectedBoletoPaymentDateResult == null)
                    expectedBoletoPaymentDateResult = FindExpectedBoletoPaymentDate(new FindExpectedBoletoPaymentDateRequest { AccountId = findBoletoInfoRequest.AccountId, ActualDatePayment = DateTime.Now, BarCode = findBoletoInfoRequest.NumericSequence });

                findInfosPaymentCIPByBarcodeResponse.PaymentDate = expectedBoletoPaymentDateResult.ExpectedBoletoPaymentDate;
                findInfosPaymentCIPByBarcodeResponse.Barcode = findBoletoInfoRequest.NumericSequence;

                findBoletoInfoResult = _mapper.Map(findInfosPaymentCIPByBarcodeResponse);

                if (!verifiyBoletoCanBePaidResponse.CanBePaid)
                    throw new OsbBusinessException(BoletoPaymentExcMsg.EXC0008);

                return findBoletoInfoResult;
            }

            throw new OsbBusinessException(BoletoPaymentExcMsg.EXC0008);
        }

        public FindExpectedBoletoPaymentDateResult FindExpectedBoletoPaymentDate(FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            _validator.Validate(findExpectedBoletoPaymentDateRequest);

            IntegrationRequest.FindExpectedBoletoPaymentDateRequest integrationRequest = _mapper.Map(findExpectedBoletoPaymentDateRequest);

            IntegrationService.IBoletoPaymentService paymentIntegrationService = _boletoPaymentIntegrationServiceFactory.Create();
            IntegrationResponse.FindExpectedBoletoPaymentDateResponse findExpectedBoletoPaymentDateResponse = paymentIntegrationService.FindExpectedBoletoPaymentDate(integrationRequest);

            FindExpectedBoletoPaymentDateResult result = _mapper.Map(findExpectedBoletoPaymentDateResponse);
            return result;
        }

        public FindScanLicenseKeyResult FindScanLicenseKey(FindScanLicenseKeyRequest findScanLicenseKeyRequest)
        {
            IBoletoPaymentRepository boletoPaymentRepository = _boletoPaymentRepositoryFactory.Create();
            ScanLicenseKey scanLicenseKey = boletoPaymentRepository.GetScanLicenseKeyByCompanyId(findScanLicenseKeyRequest.CompanyId);

            FindScanLicenseKeyResult findScanLicenseKeyResult = _mapper.Map(scanLicenseKey);

            return findScanLicenseKeyResult;
        }
    }
}
