using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Service.Models.Result;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Util.Resources.TaxPaymentExcMsg;
using Osb.Core.Platform.Business.Service.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Business.Service
{
    public class TaxPaymentService : ITaxPaymentService
    {
        private readonly ITaxPaymentServiceFactory _taxPaymentIntegrationServiceFactory;
        private readonly ITaxPaymentRepositoryFactory _taxPaymentRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly Settings _settings;
        private IConnectionFactory _connectionFactory;
        private readonly IOperationRepositoryFactory _operationRepositoryFactory;
        private readonly IOperationTagRepositoryFactory _operationTagRepositoryFactory;
        private readonly TaxPaymentMapper _mapper;
        private readonly TaxPaymentValidator _validator;

        public TaxPaymentService(
            ITaxPaymentServiceFactory taxPaymentIntegrationServiceFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            Settings settings,
            IConnectionFactory connectionFactory,
            IOperationRepositoryFactory operationRepositoryFactory,
            IOperationTagRepositoryFactory operationTagRepositoryFactory,
            ITaxPaymentRepositoryFactory taxPaymentRepositoryFactory)
        {
            _taxPaymentIntegrationServiceFactory = taxPaymentIntegrationServiceFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _settings = settings;
            _connectionFactory = connectionFactory;
            _operationRepositoryFactory = operationRepositoryFactory;
            _operationTagRepositoryFactory = operationTagRepositoryFactory;
            _mapper = new TaxPaymentMapper();
            _validator = new TaxPaymentValidator();
            _taxPaymentRepositoryFactory = taxPaymentRepositoryFactory;
        }

        public OperationResult SaveFGTSPayment(FGTSPaymentRequest fgtsPaymentRequest)
        {
            _validator.Validate(fgtsPaymentRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(fgtsPaymentRequest.UserId, OperationType.FGTSPayment);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                if (fgtsPaymentRequest.Tags != null)
                {
                    IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
                    foreach (string tag in fgtsPaymentRequest.Tags)
                    {
                        OperationTag operationTag = OperationTag.Create(operation.OperationId, tag, fgtsPaymentRequest.UserId);
                        operationTagRepository.Save(operationTag, transactionScope);
                    }
                }

                FGTSPayment fgtsPayment = FGTSPayment.Create(
                                                        fgtsPaymentRequest.AccountId,
                                                        operation.OperationId,
                                                        fgtsPaymentRequest.UserId,
                                                        fgtsPaymentRequest.TaxId,
                                                        fgtsPaymentRequest.ContributorTaxId,
                                                        fgtsPaymentRequest.PrincipalValue,
                                                        fgtsPaymentRequest.CodeRevenue,
                                                        fgtsPaymentRequest.Barcode,
                                                        fgtsPaymentRequest.FgtsIdentifier,
                                                        fgtsPaymentRequest.SocialConnectivityCode,
                                                        fgtsPaymentRequest.SocialConnectivityDigit,
                                                        fgtsPaymentRequest.PaymentDate,
                                                        fgtsPaymentRequest.RateValueType,
                                                        fgtsPaymentRequest.Description
                                                        );

                ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();
                taxPaymentRepository.Save(fgtsPayment, transactionScope);

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

        public void GenerateFGTSPayment(FGTSPayment FGTSPayment)
        {
            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(FGTSPayment.AccountId);

            IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
            IEnumerable<OperationTag> operationTags = operationTagRepository.GetOperationTagsByOperationId(FGTSPayment.OperationId);

            ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();

            IntegrationRequest.FGTSPaymentRequest integrationRequest = _mapper.Map(FGTSPayment, account, operationTags);
            IntegrationService.ITaxPaymentService taxPaymentIntegrationService = _taxPaymentIntegrationServiceFactory.Create();

            IntegrationResponse.FGTSPaymentResponse FGTSPaymentResponse = taxPaymentIntegrationService.GenerateFGTSPayment(integrationRequest);

            if (FGTSPaymentResponse.ResponseStatus)
            {
                FGTSPayment.Status = FGTSPaymentStatus.Generated;
                FGTSPayment.ExternalIdentifier = FGTSPaymentResponse.ExternalIdentifier;
            }
            else
            {
                FGTSPayment.Attempts += 1;

                if (FGTSPayment.Attempts >= _settings.Attempts)
                    FGTSPayment.Status = FGTSPaymentStatus.Error;
            }

            taxPaymentRepository.Update(FGTSPayment);
        }

        public void UpdateFGTSpayment(FGTSPayment FGTSPayment)
        {
            ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();

            taxPaymentRepository.Update(FGTSPayment);
        }

        public IEnumerable<FGTSPayment> FindFGTSPaymentListByStatus(FGTSPaymentStatus Status)
        {
            ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();
            IEnumerable<FGTSPayment> FGTSPaymentList = taxPaymentRepository.GetListByStatus(Status);

            return FGTSPaymentList;
        }

        public OperationResult SaveDARJPayment(DARJPaymentRequest darjPaymentRequest)
        {
            _validator.Validate(darjPaymentRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(darjPaymentRequest.AccountId);

            if (account == null)
                throw new OsbBusinessException(TaxPaymentExcMsg.EXC0013);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(darjPaymentRequest.UserId, OperationType.DARJPayment);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                if (darjPaymentRequest.Tags != null)
                {
                    IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
                    foreach (string tag in darjPaymentRequest.Tags)
                    {
                        OperationTag operationTag = OperationTag.Create(operation.OperationId, tag, darjPaymentRequest.UserId);
                        operationTagRepository.Save(operationTag, transactionScope);
                    }
                }

                DARJPayment darjPayment = DARJPayment.Create(darjPaymentRequest.AccountId,
                                                            darjPaymentRequest.UserId,
                                                            operation.OperationId,
                                                            darjPaymentRequest.TaxId,
                                                            darjPaymentRequest.ContributorTaxId,
                                                            darjPaymentRequest.ReferenceNumber,
                                                            darjPaymentRequest.PrincipalValue,
                                                            darjPaymentRequest.FineValue,
                                                            darjPaymentRequest.InterestValue,
                                                            darjPaymentRequest.MonetaryValue,
                                                            darjPaymentRequest.TotalValue,
                                                            darjPaymentRequest.RateValue,
                                                            darjPaymentRequest.DueDate,
                                                            darjPaymentRequest.CodeRevenue,
                                                            darjPaymentRequest.StateRegistration,
                                                            darjPaymentRequest.OriginDocument,
                                                            darjPaymentRequest.PaymentDate,
                                                            darjPaymentRequest.RateValueType,
                                                            darjPaymentRequest.Description
                                                            );

                ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();
                taxPaymentRepository.Save(darjPayment, transactionScope);

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

        public IEnumerable<DARJPayment> FindDARJPaymentByStatus(DARJPaymentStatus status)
        {
            ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();
            IEnumerable<DARJPayment> darjPayments = taxPaymentRepository.GetDARJPaymentListByStatus(status);

            return darjPayments;
        }

        public void GenerateDARJPayment(DARJPayment darjPayment)
        {
            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(darjPayment.AccountId);

            IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
            IEnumerable<OperationTag> operationTags = operationTagRepository.GetOperationTagsByOperationId(darjPayment.OperationId);

            IntegrationRequest.DARJPaymentRequest integrationRequest = _mapper.Map(darjPayment, account, operationTags);

            IntegrationService.ITaxPaymentService taxPaymentService = _taxPaymentIntegrationServiceFactory.Create();
            IntegrationResponse.DARJPaymentResponse darjPaymentResponse = taxPaymentService.GeneratePaymentDARJ(integrationRequest);

            ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();

            if (darjPaymentResponse.ResponseStatus)
            {
                darjPayment.Status = DARJPaymentStatus.Generated;
                darjPayment.ExternalIdentifier = darjPaymentResponse.ExternalIdentifier;
            }
            else
            {
                darjPayment.Attempts += 1;

                if (darjPayment.Attempts >= _settings.Attempts)
                    darjPayment.Status = DARJPaymentStatus.Error;
            }

            taxPaymentRepository.Update(darjPayment);
        }

        public void UpdateDARJPayment(DARJPayment darjPayment)
        {
            ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();
            taxPaymentRepository.Update(darjPayment);
        }

        public OperationResult SaveGAREPayment(GAREPaymentRequest garePaymentRequest)
        {
            _validator.Validate(garePaymentRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                Operation operation = Operation.Create(garePaymentRequest.UserId, OperationType.GAREPayment);
                IOperationRepository operationRepository = _operationRepositoryFactory.Create();
                operation = operationRepository.Save(operation, transactionScope);

                if (garePaymentRequest.Tags != null)
                {
                    IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();

                    foreach (string tag in garePaymentRequest.Tags)
                    {
                        OperationTag operationTag = OperationTag.Create(operation.OperationId, tag, garePaymentRequest.UserId);
                        operationTagRepository.Save(operationTag, transactionScope);
                    }
                }

                GAREPayment garePayment = GAREPayment.Create(garePaymentRequest.AccountId,
                                                            operation.OperationId,
                                                            garePaymentRequest.TaxId,
                                                            garePaymentRequest.ContributorTaxId,
                                                            garePaymentRequest.ReferenceNumber,
                                                            garePaymentRequest.PrincipalValue,
                                                            garePaymentRequest.FineValue,
                                                            garePaymentRequest.InterestValue,
                                                            garePaymentRequest.TotalValue,
                                                            garePaymentRequest.RateValue,
                                                            garePaymentRequest.DueDate,
                                                            garePaymentRequest.PaymentDate,
                                                            garePaymentRequest.CodeRevenue,
                                                            garePaymentRequest.StateRegistration,
                                                            garePaymentRequest.ActiveDebit,
                                                            garePaymentRequest.QuoteNumberNotification,
                                                            garePaymentRequest.RateValueType,
                                                            garePaymentRequest.Description,
                                                            garePaymentRequest.GAREType,
                                                            garePaymentRequest.UserId
                                                            );

                ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();
                taxPaymentRepository.Save(garePayment, transactionScope);

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

        public IEnumerable<GAREPayment> FindGAREPaymentListByStatus(GAREPaymentStatus status)
        {
            ITaxPaymentRepository taxPaymentRepository = _taxPaymentRepositoryFactory.Create();
            IEnumerable<GAREPayment> garePaymentList = taxPaymentRepository.GetListByStatus(status);

            return garePaymentList;
        }

        public void GenerateGAREPayment(GAREPayment garePayment)
        {
            ITaxPaymentRepository garePaymentRepository = _taxPaymentRepositoryFactory.Create();

            IOperationTagRepository operationTagRepository = _operationTagRepositoryFactory.Create();
            IEnumerable<OperationTag> operationTags = operationTagRepository.GetOperationTagsByOperationId(garePayment.OperationId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(garePayment.AccountId);

            IntegrationRequest.GAREPaymentRequest integrationRequest = _mapper.Map(garePayment, account, operationTags);

            IntegrationService.ITaxPaymentService garePaymentIntegrationService = _taxPaymentIntegrationServiceFactory.Create();
            IntegrationResponse.GAREPaymentResponse garePaymentResponse = garePaymentIntegrationService.GenerateGAREPayment(integrationRequest);

            if (garePaymentResponse.ResponseStatus)
            {
                garePayment.Status = GAREPaymentStatus.Generated;
                garePayment.ExternalIdentifier = garePaymentResponse.ExternalIdentifier;
            }
            else
            {
                garePayment.Attempts += 1;

                if (garePayment.Attempts >= _settings.Attempts)
                    garePayment.Status = GAREPaymentStatus.Error;
            }

            garePaymentRepository.Update(garePayment);
        }

        public void UpdateGAREPayment(GAREPayment garePayment)
        {
            ITaxPaymentRepository garePaymentRepository = _taxPaymentRepositoryFactory.Create();

            garePaymentRepository.Update(garePayment);
        }
    }
}

