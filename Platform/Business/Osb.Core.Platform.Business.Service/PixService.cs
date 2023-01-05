using System;
using System.Linq;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Validators;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Common.Entity.Enums;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Business.Util.Resources.PixMsg;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Business.Util;

namespace Osb.Core.Platform.Business.Service
{
    public class PixService : IPixService
    {
        private readonly PixValidator _validator;
        private readonly PixMapper _mapper;
        private readonly BankMapper _bankMapper;
        private readonly IPixServiceFactory _pixIntegrationServiceFactory;
        private readonly IPixRepositoryFactory _pixRepositoryFactory;
        private readonly IOperationRepositoryFactory _operationRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IOperationTagRepositoryFactory _operationTagRepositoryFactory;
        private readonly INotificationRepositoryFactory _notificationRepositoryFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;
        private readonly INotificationService _notificationService;
        private readonly IFavoredRepositoryFactory _favoredRepositoryFactory;
        private readonly IBankServiceFactory _bankServiceFactory;
        private IConnectionFactory _connectionFactory;
        private readonly Settings _settings;

        public PixService(
            IPixServiceFactory pixIntegrationServiceFactory,
            IPixRepositoryFactory pixRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IUserAccountRepository userAccountRepository,
            IOperationRepositoryFactory operationRepositoryFactory,
            IOperationTagRepositoryFactory operationTagRepositoryFactory,
            INotificationRepositoryFactory notificationRepositoryFactory,
            IUserRepositoryFactory userRepositoryFactory,
            INotificationService notificationService,
            IFavoredRepositoryFactory favoredRepositoryFactory,
            IBankServiceFactory bankServiceFactory,
            IConnectionFactory connectionFactory,
            Settings settings
        )
        {
            _pixIntegrationServiceFactory = pixIntegrationServiceFactory;
            _pixRepositoryFactory = pixRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _userAccountRepository = userAccountRepository;
            _operationTagRepositoryFactory = operationTagRepositoryFactory;
            _favoredRepositoryFactory = favoredRepositoryFactory;
            _mapper = new PixMapper();
            _validator = new PixValidator();
            _settings = settings;
            _connectionFactory = connectionFactory;
            _operationRepositoryFactory = operationRepositoryFactory;
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _userRepositoryFactory = userRepositoryFactory;
            _bankServiceFactory = bankServiceFactory;
            _connectionFactory = connectionFactory;
            _settings = settings;
            _notificationService = notificationService;
            _mapper = new PixMapper();
            _bankMapper = new BankMapper();
            _validator = new PixValidator();
        }

        public CreatePixKeyResult CreatePixKey(CreatePixKeyRequest createPixKeyRequest)
        {
            _validator.Validate(createPixKeyRequest);


            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            IPixRepository pixRepository = _pixRepositoryFactory.Create();

            IntegrationRequest.CreatePixKeyRequest integrationRequest = _mapper.Map(createPixKeyRequest);

            IntegrationService.IPixService pixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.CreatePixKeyResponse createPixKeyResponse = pixIntegrationService.CreatePixKey(integrationRequest);

            if (!createPixKeyResponse.ResponseStatus)
                throw new OsbBusinessException(createPixKeyResponse.Message);

            CreatePixKeyResult result = new CreatePixKeyResult();
            result.PixKeyValue = createPixKeyResponse.Key;

            return result;

        }

        public FindPixKeyListResult FindPixKeyList(FindPixKeyListRequest findPixKeyListRequest)
        {
            _validator.Validate(findPixKeyListRequest);

            IntegrationRequest.FindPixKeyListRequest integrationRequest = _mapper.Map(findPixKeyListRequest);

            IntegrationService.IPixService pixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.FindPixKeyListResponse findPixKeyListResponse = pixIntegrationService.FindPixKeyList(integrationRequest);

            FindPixKeyListResult result = _mapper.Map(findPixKeyListResponse);

            result.PixKeyList.ToList().RemoveAll(x => x.Status != PixKeyStatus.Registering || x.Status != PixKeyStatus.Registered);

            return result;
        }

        public ConfirmPixKeyHoldResult ConfirmPixKeyHold(ConfirmPixKeyHoldRequest confirmPixKeyHoldRequest)
        {
            _validator.Validate(confirmPixKeyHoldRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(confirmPixKeyHoldRequest.AccountId);

            IntegrationRequest.ConfirmPixKeyHoldRequest integrationRequest = _mapper.Map(confirmPixKeyHoldRequest, account);

            IntegrationService.IPixService pixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.ConfirmPixKeyHoldResponse confirmPixKeyHoldResponse = pixIntegrationService.ConfirmPixKeyHold(integrationRequest);

            ConfirmPixKeyHoldResult result = _mapper.Map(confirmPixKeyHoldResponse);

            return result;

        }

        public ResendPixKeyTokenResult ResendPixKeyToken(ResendPixKeyTokenRequest resendPixKeyTokenRequest)
        {
            _validator.Validate(resendPixKeyTokenRequest);

            IntegrationRequest.ResendPixKeyTokenRequest integrationRequest = _mapper.Map(resendPixKeyTokenRequest);

            IntegrationService.IPixService pixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.ResendPixKeyTokenResponse resendPixKeyTokenResponse = pixIntegrationService.ResendPixKeyToken(integrationRequest);

            ResendPixKeyTokenResult result = _mapper.Map(resendPixKeyTokenResponse);

            return result;
        }

        public CancelPixKeyResult CancelPixKey(CancelPixKeyRequest cancelPixKeyRequest)
        {
            _validator.Validate(cancelPixKeyRequest);

            IntegrationRequest.CancelPixKeyRequest integrationRequest = _mapper.Map(cancelPixKeyRequest);

            IntegrationService.IPixService PixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.CancelPixKeyResponse cancelPixKeyResponse = PixIntegrationService.CancelPixKey(integrationRequest);

            CancelPixKeyResult result = _mapper.Map(cancelPixKeyResponse);

            return result;
        }

        public FindInfosPixKeyResult FindInfosPixKey(FindInfosPixKeyRequest findInfosPixKeyRequest)
        {
            _validator.Validate(findInfosPixKeyRequest);

            IntegrationRequest.FindInfosPixKeyRequest integrationRequest = _mapper.Map(findInfosPixKeyRequest);

            IntegrationService.IPixService PixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.ExternalFindInfosPixKeyResponse FindInfosPixKeyResponse = PixIntegrationService.FindInfosPixKey(integrationRequest);

            IntegrationService.IBankService bankService = _bankServiceFactory.Create();

            IntegrationRequest.FindBanksRequest findBanksRequest = new IntegrationRequest.FindBanksRequest()
            {
                AccountId = findInfosPixKeyRequest.AccountId,
                UserId = findInfosPixKeyRequest.UserId
            };

            IntegrationResponse.FindBanksResponse findBanksResponse = bankService.FindBanks(findBanksRequest);

            FindBanksResult bankListResult = _bankMapper.Map(findBanksResponse);

            Bank bank = bankListResult.Banks.FirstOrDefault(x => x.Code == FindInfosPixKeyResponse.FindInfosPixKeyResponse.PayeeBank);

            FindInfosPixKeyResult result = _mapper.Map(FindInfosPixKeyResponse, bank);

            return result;
        }

        public OperationResult SavePixOut(GeneratePixOutRequest generatePixOutRequest)
        {
            _validator.Validate(generatePixOutRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(generatePixOutRequest.UserId, OperationType.PixOut);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                Account fromAccount = accountRepository.GetById(generatePixOutRequest.AccountId);

                operation = operationRepository.Save(operation, transactionScope);

                if (generatePixOutRequest.Tags != null)
                {
                    IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();

                    foreach (string tag in generatePixOutRequest.Tags)
                    {
                        OperationTag operationTag = OperationTag.Create(operation.OperationId, tag, generatePixOutRequest.UserId);
                        operationTagRepository.Save(operationTag, transactionScope);
                    }
                }

                IFavoredRepository favoredRepository = _favoredRepositoryFactory.Create();
                Favored favored = favoredRepository.GetFavored(
                                                                fromAccount.AccountId,
                                                                generatePixOutRequest.ToTaxId,
                                                                generatePixOutRequest.ToBank,
                                                                generatePixOutRequest.ToBankBranch,
                                                                generatePixOutRequest.ToBankAccount,
                                                                generatePixOutRequest.ToBankAccountDigit,
                                                                OperationType.PixOut
                );

                if (favored == null)
                {
                    favored = Favored.Create(generatePixOutRequest.UserId, fromAccount.AccountId,
                                             generatePixOutRequest.ToTaxId, generatePixOutRequest.ToName,
                                             OperationType.PixOut, generatePixOutRequest.ToBankName,
                                             generatePixOutRequest.ToBank, generatePixOutRequest.ToBankBranch,
                                             generatePixOutRequest.ToBankAccount, generatePixOutRequest.ToBankAccountDigit
                    );

                    favoredRepository.Save(favored, transactionScope);
                }
                else
                    favoredRepository.UpdateFavored(favored);

                PixOut pixOut = PixOut.Create(generatePixOutRequest.AccountId, operation.OperationId, generatePixOutRequest.UserId, generatePixOutRequest.ToName, generatePixOutRequest.ToTaxId,
                                            generatePixOutRequest.ToBank, generatePixOutRequest.ToBankBranch, generatePixOutRequest.ToBankAccount, generatePixOutRequest.ToBankAccountDigit,
                                            generatePixOutRequest.Value, generatePixOutRequest.PaymentDate, generatePixOutRequest.CustomerMessage, generatePixOutRequest.PixKey,
                                            generatePixOutRequest.PixKeyType, generatePixOutRequest.Description, generatePixOutRequest.AccountType, null);

                IPixRepository pixRepository = _pixRepositoryFactory.Create();
                pixRepository.Save(pixOut, transactionScope);

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

        public void GeneratePixOut(PixOut pixOut)
        {
            IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
            IEnumerable<OperationTag> operationTags = operationTagRepository.GetOperationTagsByOperationId(pixOut.OperationId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(pixOut.AccountId);

            IntegrationRequest.GeneratePixOutRequest integrationRequest = _mapper.Map(pixOut, account, operationTags);

            IntegrationService.IPixService pixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.GeneratePixOutResponse response = pixIntegrationService.GeneratePixOut(integrationRequest);

            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
            IUserRepository userRepository = _userRepositoryFactory.Create();

            UserInformation userInformation = userRepository.GetByUserId(pixOut.CreationUserId);

            if (response.ResponseStatus)
            {
                pixOut.Status = PixOutStatus.Generated;
                pixOut.ExternalIdentifier = response.ExternalIdentifier;
                pixOut.ResponseMessage = response.Message;

                if (_settings.SuccessEmailNotification)
                    Notification.SendMail(account.CompanyId, userInformation, notificationRepository, PixInfoMsg.INFO0001, PixInfoMsg.INFO0002);

                if (_settings.SuccessSmsNotification)
                    Notification.SendSms(account.CompanyId, userInformation, notificationRepository, PixInfoMsg.INFO0002);

                if (_settings.SuccessPushNotification)
                    Notification.SendPush(account.CompanyId, pixOut.OperationId, userInformation, notificationRepository, PixInfoMsg.INFO0001, PixInfoMsg.INFO0002);
            }
            else
            {
                pixOut.Status = PixOutStatus.Error;
                pixOut.ResponseMessage = response.Message;

                if (_settings.FailureEmailNotification)
                    Notification.SendMail(account.CompanyId, userInformation, notificationRepository, PixInfoMsg.INFO0001, string.Format(PixInfoMsg.INFO0003, response.Message));

                if (_settings.FailureSmsNotification)
                    Notification.SendSms(account.CompanyId, userInformation, notificationRepository, string.Format(PixInfoMsg.INFO0003, response.Message));

                if (_settings.FailurePushNotification)
                    Notification.SendPush(account.CompanyId, pixOut.OperationId, userInformation, notificationRepository, PixInfoMsg.INFO0001, string.Format(PixInfoMsg.INFO0003, response.Message));
            }

            IPixRepository pixRepository = _pixRepositoryFactory.Create();
            pixRepository.Update(pixOut);
        }

        public void UpdatePixOut(PixOut pixOut)
        {
            IPixRepository pixRepository = _pixRepositoryFactory.Create();
            pixRepository.Update(pixOut);
        }

        public IEnumerable<PixOut> FindPixOutByStatus(PixOutStatus pixOutStatus)
        {
            IPixRepository pixRepository = _pixRepositoryFactory.Create();
            IEnumerable<PixOut> pixOutList = pixRepository.GetByStatus(pixOutStatus);

            return pixOutList;
        }

        public OperationResult CreateRefundPixIn(RefundPixInRequest refundPixInRequest)
        {
            _validator.Validate(refundPixInRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(refundPixInRequest.UserId, OperationType.RefundPixIn);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                if (refundPixInRequest.Tags != null)
                {
                    IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
                    foreach (string tag in refundPixInRequest.Tags)
                    {
                        OperationTag operationTag = OperationTag.Create(operation.OperationId, tag, refundPixInRequest.UserId);
                        operationTagRepository.Save(operationTag, transactionScope);
                    }
                }

                RefundPixIn refundPixIn = RefundPixIn.Create(
                                                        refundPixInRequest.UserId,
                                                        refundPixInRequest.AccountId,
                                                        refundPixInRequest.ToTaxId,
                                                        refundPixInRequest.ToName,
                                                        refundPixInRequest.ToBank,
                                                        refundPixInRequest.ToBankAccount,
                                                        refundPixInRequest.ToBankBranch,
                                                        refundPixInRequest.ToBankAccountDigit,
                                                        refundPixInRequest.RefundValue,
                                                        refundPixInRequest.CustomerMessage,
                                                        refundPixInRequest.DocumentNumber,
                                                        operation.OperationId
                                                    );

                IPixRepository pixRepository = _pixRepositoryFactory.Create();
                pixRepository.Save(refundPixIn, transactionScope);

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

        public void GenerateRefundPixIn(RefundPixIn refundPixIn)
        {
            IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
            IEnumerable<OperationTag> operationTags = operationTagRepository.GetOperationTagsByOperationId(refundPixIn.OperationId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(refundPixIn.AccountId);

            if (string.IsNullOrEmpty(account.SPBBank) || string.IsNullOrEmpty(account.SPBBankBranch) || string.IsNullOrEmpty(account.SPBBankAccount) || string.IsNullOrEmpty(account.SPBBankAccountDigit))
                throw new OsbBusinessException(PixExcMsg.EXC0007);

            IntegrationRequest.RefundPixInRequest integrationRequest = _mapper.Map(refundPixIn, account, operationTags);

            IntegrationService.IPixService refundPixInIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.RefundPixInResponse response = refundPixInIntegrationService.GenerateRefundPixIn(integrationRequest);

            if (response.ResponseStatus)
            {
                refundPixIn.ExternalIdentifier = response.ExternalIdentifier;
                refundPixIn.Status = RefundPixInStatus.Generated;
            }
            else
            {
                if (++refundPixIn.Attempts == _settings.Attempts)
                    refundPixIn.Status = RefundPixInStatus.Error;
            }

            Update(refundPixIn);
        }

        public IEnumerable<RefundPixIn> FindRefundPixInListByStatus(RefundPixInStatus refundPixInStatus)
        {
            IPixRepository pixRepository = _pixRepositoryFactory.Create();
            IEnumerable<RefundPixIn> refundPixIns = pixRepository.GetByStatus(refundPixInStatus);

            return refundPixIns;
        }

        public void Update(RefundPixIn refundPixIn)
        {
            IPixRepository pixRepository = _pixRepositoryFactory.Create();
            pixRepository.Update(refundPixIn);
        }

        public PixQRCodeResult GenerateStaticPixQRCode(GenerateStaticPixQRCodeRequest generateStaticPixQRCodeRequest)
        {
            _validator.Validate(generateStaticPixQRCodeRequest);

            IPixRepository pixRepository = _pixRepositoryFactory.Create();

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(generateStaticPixQRCodeRequest.AccountId);

            IntegrationRequest.GenerateStaticPixQRCodeRequest integrationRequestGenerate = _mapper.Map(generateStaticPixQRCodeRequest, account);

            IntegrationService.IPixService pixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.GenerateStaticPixQRCodeResponse generateStaticPixQRCodeResponse = pixIntegrationService.GenerateStaticPixQRCode(integrationRequestGenerate);

            if (!generateStaticPixQRCodeResponse.ResponseStatus)
                throw new OsbBusinessException(generateStaticPixQRCodeResponse.Message);

            PixQRCodeResult result = _mapper.Map(generateStaticPixQRCodeResponse);

            return result;
        }

        public PixQRCodeResult GenerateDynamicPixQrCode(GenerateDynamicPixQrCodeRequest generateDynamicPixQrCodeRequest)
        {
            _validator.Validate(generateDynamicPixQrCodeRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(generateDynamicPixQrCodeRequest.AccountId);

            IntegrationService.IPixService pixIntegrationService = _pixIntegrationServiceFactory.Create();

            IntegrationRequest.GenerateDynamicPixQrCodeRequest integrationRequestGenerate = _mapper.Map(generateDynamicPixQrCodeRequest, account);
            IntegrationResponse.GenerateDynamicPixQrCodeResponse generateDynamicPixQRCodeResponse = pixIntegrationService.GenerateDynamicPixQrCode(integrationRequestGenerate);

            // GetPixQRCodeRequest getPixQRCodeRequest = GetPixQRCodeRequest.Create(generateDynamicPixQRCodeResponse.ExternalIdentifier, account.TaxId, account.AccountId);
            // PixQRCode qrCode = GetPixQrCode(getPixQRCodeRequest);
            // PixQRCodeResult result = _mapper.Map(qrCode);

            return null;
        }

        public PixQRCode FindPixQrCode(FindPixQrCodeRequest findPixQrCodeRequest)
        {
            _validator.Validate(findPixQrCodeRequest);

            IntegrationService.IPixService pixIntegrationService = _pixIntegrationServiceFactory.Create();

            IntegrationRequest.FindPixQRCodeRequest integrationRequestGet = _mapper.Map(findPixQrCodeRequest.ExternalIdentifier, findPixQrCodeRequest.AccountId, findPixQrCodeRequest.TaxId);
            IntegrationResponse.FindPixQRCodeResponse findPixQRCodeResponse = pixIntegrationService.FindPixQRCode(integrationRequestGet);

            DateTime initialDate = DateTime.Now;

            while ((findPixQRCodeResponse.PixQRCode.HashCode == " " && findPixQRCodeResponse.PixQRCode.QRCodeBase64 == " "))
            {
                findPixQRCodeResponse = pixIntegrationService.FindPixQRCode(integrationRequestGet);

                TimeSpan elapsedTime = DateTime.Now - initialDate;
                if (elapsedTime.Seconds >= 10)
                    throw new OsbBusinessException(PixExcMsg.EXC0022);
            };

            PixQRCode result = _mapper.Map(findPixQRCodeResponse);
            return result;
        }

        public FindInfoPixQRCodeResult FindInfoPixQRCode(FindInfoPixQRCodeRequest findInfoPixQRCodeRequest)
        {
            _validator.Validate(findInfoPixQRCodeRequest);

            IntegrationRequest.FindInfoPixQRCodeRequest integrationRequest = _mapper.Map(findInfoPixQRCodeRequest);

            IntegrationService.IPixService PixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.FindInfoPixQRCodeResponse findInfoPixQRCodeResponse = PixIntegrationService.FindInfoPixQRCode(integrationRequest);

            FindInfoPixQRCodeResult result = _mapper.Map(findInfoPixQRCodeResponse);

            return result;
        }

        public void ClaimPixKey(PixKey pixKey)
        {

            IPixRepository pixRepository = _pixRepositoryFactory.Create();
            IAccountRepository accountRepository = _accountRepositoryFactory.Create();

            Account account = accountRepository.GetById(pixKey.AccountId);

            IntegrationRequest.ClaimPixKeyRequest integrationRequest = _mapper.Map(pixKey, account);

            IntegrationService.IPixService pixIntegrationService = _pixIntegrationServiceFactory.Create();
            IntegrationResponse.ClaimPixKeyResponse claimPixKeyResponse = pixIntegrationService.ClaimPixKey(integrationRequest);

            if (claimPixKeyResponse.ResponseStatus)
                pixKey.Status = PixKeyStatus.Claiming;
            else
                pixKey.Status = PixKeyStatus.Error;

            pixRepository.UpdatePixKey(pixKey);
        }

        public void UpdatePixKey(PixKey pixKey)
        {
            IPixRepository pixRepository = _pixRepositoryFactory.Create();
            pixRepository.UpdatePixKey(pixKey);
        }

        public IEnumerable<PixKey> FindPixKeyListByStatus(PixKeyStatus pixKeyStatus)
        {
            IPixRepository pixRepository = _pixRepositoryFactory.Create();
            IEnumerable<PixKey> pixKeyList = pixRepository.GetPixKeyListByStatus(pixKeyStatus);

            return pixKeyList;
        }

        public void UpdatePixKeyStatus(UpdatePixKeyStatusRequest updatePixKeyStatusRequest)
        {
            _validator.Validate(updatePixKeyStatusRequest);

            IPixRepository pixRepository = _pixRepositoryFactory.Create();

            PixKey pixKey = pixRepository.GetPixKeyByPixKeyValue(updatePixKeyStatusRequest.PixKeyType, updatePixKeyStatusRequest.PixKey);

            if (pixKey != null)
            {
                pixKey.Status = updatePixKeyStatusRequest.PixKeyStatus;
                pixKey.PixKeyValue = updatePixKeyStatusRequest.PixKey;

                pixRepository.UpdatePixKey(pixKey);
            }
            else
            {
                IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                Account account = accountRepository.GetBySpbAccount(updatePixKeyStatusRequest.Bank, updatePixKeyStatusRequest.BankBranch, updatePixKeyStatusRequest.BankAccount, updatePixKeyStatusRequest.BankAccountDigit);

                if (account != null)
                {
                    PixKey newPixKey = PixKey.Create(account.AccountId,
                                                    default(long),
                                                    updatePixKeyStatusRequest.PixKeyType,
                                                    updatePixKeyStatusRequest.PixKey,
                                                    updatePixKeyStatusRequest.PixKeyStatus
                                                    );

                    pixRepository.SavePixKey(newPixKey);
                }
            }
        }

        public void NotificationPixIn(PixInRequest pixInRequest)
        {
            _validator.Validate(pixInRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();

            if (pixInRequest.Status == PixOutStatus.Paid)
            {
                Account account = accountRepository.GetBySpbAccountAndTaxId(pixInRequest.ToTaxNumber, pixInRequest.ToBankNumber,
                                                     pixInRequest.ToBankBranch, pixInRequest.ToBankAccount,
                                                     pixInRequest.ToBankAccountDigit);
                if (account != null)
                {
                    IEnumerable<UserAccount> users = _userAccountRepository.GetUsersByAccountId(account.AccountId);

                    if (users != null)
                    {
                        foreach (UserAccount user in users)
                        {
                            PushNotification pushNotification = PushNotification.Create(
                                null,
                                user.UserId,
                                account.CompanyId,
                                PushNotificationMsg.MSG_TITLE_0004,
                                string.Format(PushNotificationMsg.MSG_SUCCESS_0004, pixInRequest.Value),
                                PushNotificationStatus.CanBeSent
                            );

                            notificationRepository.Save(pushNotification);
                        }
                    }
                }
            }
        }

        public void UpdateStatus(UpdatePixRequest UpdatePixRequest)
        {
            _validator.Validate(UpdatePixRequest);

            if (UpdatePixRequest.Status == PixOutStatus.Paid || UpdatePixRequest.Status == PixOutStatus.Canceled)
            {

                IPixRepository pixOutRepository = _pixRepositoryFactory.Create();
                IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();

                PixOut pixOut = new PixOut();

                if (UpdatePixRequest.PixOutId != null)
                    pixOut = pixOutRepository.GetById(UpdatePixRequest.PixOutId.Value);
                else
                    pixOut = pixOutRepository.GetByExternalIdentifier(UpdatePixRequest.ExternalIdentifier.Value);

                if (pixOut != null)
                {
                    pixOut.Status = UpdatePixRequest.Status;
                    pixOut.UpdateUserId = UpdatePixRequest.UserId;

                    string message = "";

                    if (UpdatePixRequest.Status == PixOutStatus.Paid)
                        message = string.Format(PushNotificationMsg.MSG_SUCCESS_0006, pixOut.Value);
                    else if (UpdatePixRequest.Status == PixOutStatus.Canceled)
                        message = string.Format(PushNotificationMsg.MSG_ERROR_0006, pixOut.Value);

                    Account account = accountRepository.GetById(pixOut.AccountId);
                    IEnumerable<UserAccount> users = _userAccountRepository.GetUsersByAccountId(pixOut.AccountId);

                    if (users != null)
                    {
                        foreach (UserAccount user in users)
                        {
                            PushNotification pushNotification = PushNotification.Create(
                                null,
                                user.UserId,
                                account.CompanyId,
                                PushNotificationMsg.MSG_TITLE_0004,
                                message,
                                PushNotificationStatus.CanBeSent
                            );

                            notificationRepository.Save(pushNotification);
                        }
                    }
                }

                pixOutRepository.Update(pixOut);
            }
        }
    }
}