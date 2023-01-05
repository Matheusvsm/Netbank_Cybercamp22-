using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Util.Resources.TopUpExcMsg;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Business.Service.Models.Result;
using System;
using System.Linq;
using NotificationMapping = Osb.Core.Platform.Integration.Service.FitBank.Mapping;
using Osb.Core.Platform.Business.Util.Resources;

namespace Osb.Core.Platform.Business.Service
{
    public class TopUpService : ITopUpService
    {
        private readonly TopUpValidator _validator;
        private readonly TopUpMapper _mapper;
        private readonly ITopUpRepositoryFactory _topUpRepositoryFactory;
        private readonly IOperationRepositoryFactory _operationRepositoryFactory;
        private readonly IOperationTagRepositoryFactory _operationTagRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly ITopUpServiceFactory _topUpIntegrationServiceFactory;
        private IConnectionFactory _connectionFactory;
        private readonly Settings _settings;
        private readonly INotificationServiceFactory _notificationServiceFactory;
        private readonly INotificationService _notificationService;
        private readonly NotificationMapping.NotificationMapper _notificationMapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationRepositoryFactory _notificationRepositoryFactory;


        public TopUpService(
            ITopUpRepositoryFactory topUpRepositoryFactory,
            ITopUpServiceFactory topUpIntegrationServiceFactory,
            IOperationRepositoryFactory operationRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IOperationTagRepositoryFactory operationTagRepositoryFactory,
            IConnectionFactory connectionFactory,
            Settings settings,
            INotificationServiceFactory notificationServiceFactory,
            INotificationService notificationService,
            INotificationRepository notificationRepository,
            INotificationRepositoryFactory notificationRepositoryFactory
        )
        {
            _validator = new TopUpValidator();
            _mapper = new TopUpMapper();
            _topUpRepositoryFactory = topUpRepositoryFactory;
            _operationRepositoryFactory = operationRepositoryFactory;
            _operationTagRepositoryFactory = operationTagRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _topUpIntegrationServiceFactory = topUpIntegrationServiceFactory;
            _connectionFactory = connectionFactory;
            _settings = settings;
            _notificationServiceFactory = notificationServiceFactory;
            _notificationService = notificationService;
            _notificationMapper = new NotificationMapping.NotificationMapper();
            _notificationRepositoryFactory = notificationRepositoryFactory;
            _notificationRepository = notificationRepository;
        }
        public FindTopUpProductListResult FindTopUpProductList(FindTopUpProductListRequest findTopUpProductsRequest)
        {
            _validator.Validate(findTopUpProductsRequest);

            IntegrationRequest.FindTopUpProductListRequest integrationRequest = _mapper.Map(findTopUpProductsRequest);

            IntegrationService.ITopUpService topUpIntegrationService = _topUpIntegrationServiceFactory.Create();
            IntegrationResponse.FindTopUpProductListResponse findTopUpProductsResponse = topUpIntegrationService.FindTopUpProductList(integrationRequest);

            FindTopUpProductListResult result = _mapper.Map(findTopUpProductsResponse);
            return result;
        }

        public OperationResult Save(GenerateTopUpRequest topUpRequest)
        {
            _validator.Validate(topUpRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(topUpRequest.UserId, OperationType.PurchaseTopUp);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                TopUp topUp = TopUp.Create(topUpRequest.AccountId,
                                            topUpRequest.UserId,
                                            topUpRequest.ProductType,
                                            topUpRequest.BatchIdentifier,
                                            topUpRequest.ProductKey,
                                            topUpRequest.ProductValue,
                                            topUpRequest.ContractIdentifier,
                                            topUpRequest.OriginNSU,
                                            operation.OperationId,
                                            topUpRequest.PeriodicRepetition,
                                            topUpRequest.TopUpDate.Date,
                                            topUpRequest.IsRecurrent
                                            );

                ITopUpRepository topUpRepository = _topUpRepositoryFactory.Create();
                topUpRepository.Save(topUp, transactionScope);

                if (topUpRequest.Tags != null)
                {
                    IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
                    foreach (string tag in topUpRequest.Tags)
                    {
                        OperationTag operationTag = OperationTag.Create(operation.OperationId, tag, topUpRequest.UserId);
                        operationTagRepository.Save(operationTag, transactionScope);
                    }
                }

                IAccountRepository accountRepository = _accountRepositoryFactory.Create();
                Account account = accountRepository.GetById(topUpRequest.AccountId);

                PushNotification pushNotification = PushNotification.Create(
                    operation.OperationId,
                    topUpRequest.UserId,
                    account.CompanyId,
                    PushNotificationMsg.MSG_TITLE_0003,
                    null,
                    PushNotificationStatus.Create
                );

                INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
                notificationRepository.Save(pushNotification, transactionScope);

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


        public void GenerateTopUp(TopUp topUp)
        {
            ITopUpRepository topUpRepository = _topUpRepositoryFactory.Create();
            IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
            IEnumerable<OperationTag> operationTags = operationTagRepository.GetOperationTagsByOperationId(topUp.OperationId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(topUp.AccountId);

            if (topUp.IsRecurrent && string.IsNullOrEmpty(topUp.OriginNSU))
            {
                FindTopUpProductListByPhoneNumberRequest findTopUpProductListByPhoneNumberRequest = new FindTopUpProductListByPhoneNumberRequest();

                findTopUpProductListByPhoneNumberRequest.PhoneNumber = topUp.ContractIdentifier;
                findTopUpProductListByPhoneNumberRequest.ProductSubType = (TopUpProductSubType)Enum.Parse(typeof(TopUpProductSubType), topUp.ContractIdentifier.Substring(0, 2), true);
                findTopUpProductListByPhoneNumberRequest.AccountId = topUp.AccountId;

                FindTopUpProductListByPhoneNumberResult result = FindTopUpProductListByPhoneNumber(findTopUpProductListByPhoneNumberRequest);

                IEnumerable<TopUpProduct> topUpProduct = result.TopUpPhoneNumberList.Where(x => x.ProductValue == topUp.ProductValue);
                TopUpProduct product = topUpProduct.ElementAt(0);

                topUp.BatchIdentifier = product.BatchIdentifier;
                topUp.ProductKey = product.ProductKey;
                topUp.OriginNSU = result.OriginNSU;

                topUpRepository.Update(topUp);
            }

            IntegrationRequest.GenerateTopUpRequest integrationRequest = _mapper.Map(topUp, account, operationTags);

            IntegrationService.ITopUpService topUpIntergrationService = _topUpIntegrationServiceFactory.Create();
            IntegrationResponse.GenerateTopUpResponse topUpResponse = topUpIntergrationService.GenerateTopUp(integrationRequest);


            if (topUpResponse.ResponseStatus)
            {
                topUp.ExternalIdentifier = topUpResponse.ExternalIdentifier;
                topUp.UrlReceipt = topUpResponse.UrlReceipt;
                topUp.OriginNSU = topUpResponse.OriginNSU;
                topUp.Status = TopUpStatus.Generated;
                topUp.Attempts = 0;
            }
            else
            {
                topUp.Attempts += 1;

                if (topUp.Attempts >= _settings.Attempts)
                    topUp.Status = TopUpStatus.Error;
            }

            topUpRepository.Update(topUp);

            if (topUpResponse.ResponseStatus && topUp.IsRecurrent && !string.IsNullOrEmpty(topUp.OriginNSU))
            {
                TransactionScope transactionScope = _connectionFactory.CreateTransaction();

                try
                {
                    Operation operation = Operation.Create(_settings.UserDefault, OperationType.PurchaseTopUp);
                    IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                    operation = operationRepository.Save(operation, transactionScope);

                    topUp.TopUpDate = topUp.TopUpDate.AddDays(topUp.PeriodicRepetition.Value);
                    topUp.BatchIdentifier = string.Empty;
                    topUp.ProductKey = string.Empty;
                    topUp.OriginNSU = string.Empty;
                    topUp.OperationId = operation.OperationId;
                    topUp.Status = TopUpStatus.Created;

                    topUpRepository.Save(topUp, transactionScope);

                    transactionScope.Transaction.Commit();
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

        public void AuthorizeTopUp(TopUp topUp)
        {
            IntegrationRequest.TopUpAuthorizeRequest integrationRequest = _mapper.Map(topUp);

            IntegrationService.ITopUpService topUpIntregrationService = _topUpIntegrationServiceFactory.Create();
            IntegrationResponse.TopUpAuthorizeResponse TopUpAuthorizeResponse = topUpIntregrationService.TopUpAuthorize(integrationRequest);

            ITopUpRepository topUpRepository = _topUpRepositoryFactory.Create();
            if (TopUpAuthorizeResponse.ResponseStatus)
            {
                topUp.Status = TopUpStatus.Authorized;
                topUp.Attempts = 0;
            }
            else
            {
                topUp.Attempts += 1;

                if (topUp.Attempts >= _settings.Attempts)
                    topUp.Status = TopUpStatus.Error;
            }

            topUpRepository.Update(topUp);
        }

        public void Update(TopUp topUp)
        {
            ITopUpRepository topUpRepository = _topUpRepositoryFactory.Create();
            topUpRepository.Update(topUp);
        }

        public void UpdateStatus(UpdateTopUpStatusRequest updateTopUpStatusRequest)
        {
            ITopUpRepository topUpRepository = _topUpRepositoryFactory.Create();
            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(updateTopUpStatusRequest.AccountId);

            TopUp topUp = topUpRepository.GetTopUpByExternalIdentifierAndProductkey(updateTopUpStatusRequest.ProductKey, updateTopUpStatusRequest.ExternalIdentifier);
            if (topUp == null)
                throw new OsbBusinessException(TopUpExcMsg.EXC0011);

            topUp.Status = updateTopUpStatusRequest.TopUpStatus;

            if (updateTopUpStatusRequest.TopUpStatus == TopUpStatus.Settlement || updateTopUpStatusRequest.TopUpStatus == TopUpStatus.Error)
            {
                INotificationRepository notificationRepository = _notificationRepositoryFactory.Create();
                PushNotification pushNotification = notificationRepository.GetByOperationId(topUp.OperationId);

                if (pushNotification != null)
                {
                    topUp.UpdateUserId = pushNotification.UserId;
                    pushNotification.Status = PushNotificationStatus.CanBeSent;

                    if (updateTopUpStatusRequest.TopUpStatus == TopUpStatus.Settlement)
                        pushNotification.Body = string.Format(PushNotificationMsg.MSG_SUCCESS_0003, topUp.ProductValue);
                    else if (updateTopUpStatusRequest.TopUpStatus == TopUpStatus.Error)
                        pushNotification.Body = string.Format(PushNotificationMsg.MSG_ERROR_0003, topUp.ProductValue);

                    notificationRepository.Update(pushNotification);
                }
            }

            topUpRepository.Update(topUp);
        }

        public FindTopUpProductListByPhoneNumberResult FindTopUpProductListByPhoneNumber(FindTopUpProductListByPhoneNumberRequest findTopUpProductListByPhoneNumberRequest)
        {
            _validator.Validate(findTopUpProductListByPhoneNumberRequest);

            IntegrationRequest.FindTopUpProductListByPhoneNumberRequest integrationRequest = _mapper.Map(findTopUpProductListByPhoneNumberRequest);

            IntegrationService.ITopUpService topUpIntegrationService = _topUpIntegrationServiceFactory.Create();
            IntegrationResponse.FindTopUpProductListByPhoneNumberResponse findTopUpListByPhoneNumberResponse = topUpIntegrationService.FindTopUpProductListByPhoneNumber(integrationRequest);

            FindTopUpProductListByPhoneNumberResult result = _mapper.Map(findTopUpListByPhoneNumberResponse);

            return result;
        }
        public IEnumerable<TopUp> FindTopUpListByStatus(TopUpStatus status)
        {
            ITopUpRepository topUpRepository = _topUpRepositoryFactory.Create();
            IEnumerable<TopUp> topUpList = topUpRepository.GetByStatus(status);

            return topUpList;
        }
        public FindTopUpPeriodicListResult FindTopUpPeriodicList(FindTopUpPeriodicListRequest findTopUpPeriodicListRequest)
        {
            ITopUpRepository topUpRepository = _topUpRepositoryFactory.Create();
            IEnumerable<TopUp> topUpList = topUpRepository.GetTopUpPeriodicList(findTopUpPeriodicListRequest.AccountId, TopUpStatus.Created);
            FindTopUpPeriodicListResult result = _mapper.Map(topUpList);

            return result;
        }

        public void CancelTopUpPeriodic(CancelTopUpPeriodicRequest cancelTopUpPeriodicRequest)
        {
            ITopUpRepository topUpRepository = _topUpRepositoryFactory.Create();

            foreach (TopUpRequest topUpRequest in cancelTopUpPeriodicRequest.TopUps)
            {
                TopUp topUp = TopUp.Create(cancelTopUpPeriodicRequest.AccountId,
                                            cancelTopUpPeriodicRequest.UserId,
                                            topUpRequest.ProductType,
                                            topUpRequest.BatchIdentifier,
                                            topUpRequest.ProductKey,
                                            topUpRequest.ProductValue,
                                            topUpRequest.ContractIdentifier,
                                            topUpRequest.OriginNSU,
                                            topUpRequest.OperationId,
                                            topUpRequest.PeriodicRepetition,
                                            topUpRequest.TopUpDate.Date,
                                            topUpRequest.IsRecurrent,
                                            TopUpStatus.Canceled,
                                            topUpRequest.TopUpId
                                            );

                topUpRepository.Update(topUp);
            };
        }

        public IEnumerable<TopUp> FindTopUpListByStatusAndTopUpDate(TopUpStatus status, DateTime date)
        {
            ITopUpRepository topUpRepository = _topUpRepositoryFactory.Create();
            IEnumerable<TopUp> topUpList = topUpRepository.GetByStatusAndDate(status, date);

            return topUpList;
        }


    }
}