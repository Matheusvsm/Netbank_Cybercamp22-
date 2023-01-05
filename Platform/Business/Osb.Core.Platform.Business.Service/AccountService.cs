using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Enums;
using System.Linq;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Util.Resources.AccountExcMsg;

namespace Osb.Core.Platform.Business.Service
{
    public class AccountService : IAccountService
    {
        private readonly AccountValidator _validator;
        private readonly AccountMapper _mapper;
        private readonly IAccountServiceFactory _accountIntegrationServiceFactory;
        private readonly ICompanyRepositoryFactory _companyRepositoryFactory;
        private readonly IOperationRepositoryFactory _operationRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly IAdditionalAccountRepositoryFactory _additionalAccountRepositoryFactory;
        private readonly IAccountLogRepositoryFactory _accountLogRepositoryFactory;
        private readonly IMoneyTransferRepositoryFactory _moneyTransferRepositoryFactory;
        private readonly IUIFunctionRepositoryFactory _uIFunctionRepositoryFactory;
        private readonly IConnectionFactory _connectionFactory;

        public AccountService(
            IAccountServiceFactory accountIntegrationServiceFactory,
            ICompanyRepositoryFactory companyRepositoryFactory,
            IOperationRepositoryFactory operationRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IAdditionalAccountRepositoryFactory additionalAccountRepositoryFactory,
            IAccountLogRepositoryFactory accountlogRepositoryFactory,
            IMoneyTransferRepositoryFactory moneyTransferRepositoryFactory,
            IUIFunctionRepositoryFactory uIFunctionRepositoryFactory,
            IConnectionFactory connectionFactory
        )
        {
            _accountIntegrationServiceFactory = accountIntegrationServiceFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _additionalAccountRepositoryFactory = additionalAccountRepositoryFactory;
            _accountLogRepositoryFactory = accountlogRepositoryFactory;
            _companyRepositoryFactory = companyRepositoryFactory;
            _operationRepositoryFactory = operationRepositoryFactory;
            _moneyTransferRepositoryFactory = moneyTransferRepositoryFactory;
            _uIFunctionRepositoryFactory = uIFunctionRepositoryFactory;
            _connectionFactory = connectionFactory;
            _mapper = new AccountMapper();
            _validator = new AccountValidator();
        }

        public void Save(AccountWebhookRequest accountWebhookRequest)
        {
            _validator.Validate(accountWebhookRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetByAccountKey(accountWebhookRequest.AccountKey);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                IAdditionalAccountRepository additionalAccountRepository = _additionalAccountRepositoryFactory.Create();

                if (account == null)
                {
                    account = Account.Create(accountWebhookRequest.CompanyId,
                                            accountWebhookRequest.Name,
                                            accountWebhookRequest.TaxId,
                                            accountWebhookRequest.AccountKey,
                                            0
                                            );

                    account = accountRepository.Save(account, transactionScope);


                    if (!string.IsNullOrEmpty(accountWebhookRequest.Bank) &&
                            !string.IsNullOrEmpty(accountWebhookRequest.BankBranch) &&
                                !string.IsNullOrEmpty(accountWebhookRequest.BankAccount) &&
                                    !string.IsNullOrEmpty(accountWebhookRequest.BankAccountDigit))
                    {
                        SubAccount subAccount = SubAccount.Create(account.AccountId,
                                                                accountWebhookRequest.Bank,
                                                                accountWebhookRequest.BankBranch,
                                                                accountWebhookRequest.BankAccount,
                                                                accountWebhookRequest.BankAccountDigit,
                                                                0
                        );

                        additionalAccountRepository.Save(subAccount, transactionScope);
                    }

                    if (accountWebhookRequest.SPBAccount != null)
                    {
                        SpbAccount spbAccount = SpbAccount.Create(account.AccountId,
                                                                accountWebhookRequest.SPBAccount.Bank,
                                                                accountWebhookRequest.SPBAccount.BankBranch,
                                                                accountWebhookRequest.SPBAccount.BankAccount,
                                                                accountWebhookRequest.SPBAccount.BankAccountDigit,
                                                                0
                                            );

                        additionalAccountRepository.Save(spbAccount, transactionScope);
                    }
                }
                else
                {
                    if (accountWebhookRequest.SPBAccount != null)
                    {
                        SpbAccount spbAccount = SpbAccount.Create(account.AccountId,
                                                                accountWebhookRequest.SPBAccount.Bank,
                                                                accountWebhookRequest.SPBAccount.BankBranch,
                                                                accountWebhookRequest.SPBAccount.BankAccount,
                                                                accountWebhookRequest.SPBAccount.BankAccountDigit,
                                                                0
                                            );

                        additionalAccountRepository.Save(spbAccount, transactionScope);
                    }
                }

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

        public FindAccountDashboardResult FindAccountDashboard(FindAccountDashboardRequest findAccountDashboardRequest)
        {
            _validator.Validate(findAccountDashboardRequest);

            FindAccountListByLoginRequest findAccountListByLoginRequest = _mapper.Map(findAccountDashboardRequest);
            FindAccountListResult findAccountListByLoginResult = FindAccountListByLogin(findAccountListByLoginRequest);
            List<Account> accountList = new List<Account>(findAccountListByLoginResult.AccountList);

            if (accountList.Count == 0)
                throw new OsbBusinessException(AccountExcMsg.EXC0013);

            Account account;
            if (findAccountDashboardRequest.AccountId.Equals(default(long)))
                account = accountList[0];
            else
                account = accountList.FirstOrDefault(x => x.AccountId == findAccountDashboardRequest.AccountId);

            IntegrationRequest.FindAccountBalanceRequest findAccountBalanceRequest = _mapper.Map(account);

            IUIFunctionRepository uIFunctionRepository = _uIFunctionRepositoryFactory.Create();
            IEnumerable<UIFunction> uIFunctionList = uIFunctionRepository.GetListByAccountIdAndUserId(account.AccountId, findAccountDashboardRequest.UserId);

            IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();

            IntegrationResponse.FindAccountBalanceResponse findAccountBalanceResponse = accountIntegrationService.FindAccountBalance(findAccountBalanceRequest);

            FindAccountDashboardResult result = _mapper.Map(account, findAccountListByLoginResult.AccountList, findAccountBalanceResponse, uIFunctionList);
            return result;
        }

        public FindAccountListResult FindAccountListByLogin(FindAccountListByLoginRequest findAccountListByLoginRequest)
        {
            _validator.Validate(findAccountListByLoginRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            IEnumerable<Account> accountList = accountRepository.GetListByLoginAndCompanyId(findAccountListByLoginRequest.Login, findAccountListByLoginRequest.CompanyId);

            FindAccountListResult result = _mapper.Map(accountList);
            return result;
        }

        public FindAccountListResult FindAccountListByUserId(long userId)
        {
            _validator.Validate(userId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            IEnumerable<Account> accountList = accountRepository.GetListByUserId(userId);

            FindAccountListResult result = _mapper.Map(accountList);

            return result;
        }

        public FindAccountListResult FindAccountListByUserIdAndCompanyId(long userId, long companyId)
        {
            _validator.Validate(userId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            IEnumerable<Account> accountList = accountRepository.GetListByUserIdAndCompanyId(userId, companyId);

            FindAccountListResult result = _mapper.Map(accountList);

            return result;
        }

        public FindAccountBalanceResult FindAccountBalance(FindAccountBalanceRequest findAccountBalanceRequest)
        {
            _validator.Validate(findAccountBalanceRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetByTaxId(findAccountBalanceRequest.TaxId,
                                                           findAccountBalanceRequest.Bank,
                                                           findAccountBalanceRequest.BankBranch,
                                                           findAccountBalanceRequest.BankAccount,
                                                           findAccountBalanceRequest.BankAccountDigit);

            if (account == null)
                throw new OsbBusinessException(AccountExcMsg.EXC0014);

            IntegrationRequest.FindAccountBalanceRequest integrationRequest = _mapper.Map(
               account
            );

            IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();
            IntegrationResponse.FindAccountBalanceResponse findAccountBalanceResponse = accountIntegrationService.FindAccountBalance(integrationRequest);

            FindAccountBalanceResult result = _mapper.Map(findAccountBalanceResponse);
            return result;
        }

        public FindBankStatementResult FindBankStatement(FindBankStatementRequest findBankStatementRequest)
        {
            _validator.Validate(findBankStatementRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetByTaxId(findBankStatementRequest.TaxId,
                                                           findBankStatementRequest.Bank,
                                                           findBankStatementRequest.BankBranch,
                                                           findBankStatementRequest.BankAccount,
                                                           findBankStatementRequest.BankAccountDigit);

            IntegrationRequest.FindBankStatementRequest integrationRequest = _mapper.Map(
                findBankStatementRequest,
                account
            );

            IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();
            IntegrationResponse.FindBankStatementResponse findBankStatementResponse = accountIntegrationService.FindBankStatement(integrationRequest);

            FindBankStatementResult findBankStatementResult = _mapper.Map(findBankStatementResponse);

            if (findBankStatementRequest.OperationType != null)
            {
                findBankStatementResult.Transactions.ForEach(
                    dayTransaction => dayTransaction.Transactions.RemoveAll(
                        transaction => transaction.OperationType != findBankStatementRequest.OperationType
                    )
                );
            }

            findBankStatementResult.Transactions.RemoveAll(
                    dayTransaction => dayTransaction.Transactions.Count == 0
                );

            return findBankStatementResult;
        }

        public FindBankStatementDetailsResult FindBankStatementDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            _validator.Validate(findBankStatementDetailsRequest);

            IntegrationRequest.FindBankStatementDetailsRequest integrationRequest = _mapper.Map(
                findBankStatementDetailsRequest
            );

            IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();
            FindBankStatementDetailsResult result = new FindBankStatementDetailsResult();

            switch (findBankStatementDetailsRequest.OperationType)
            {
                case OperationType.InternalTransfer:
                    IntegrationResponse.FindInternalTransferDetailsResponse findInternalTransferDetailsResponse = accountIntegrationService.FindInternalTransferDetails(integrationRequest);
                    result = _mapper.Map(findInternalTransferDetailsResponse);
                    break;
                case OperationType.MoneyTransfer:
                    IntegrationResponse.FindMoneyTransferDetailsResponse findMoneyTransferDetailsResponse = accountIntegrationService.FindMoneyTransferDetails(integrationRequest);
                    result = _mapper.Map(findMoneyTransferDetailsResponse);
                    break;
                case OperationType.BoletoPayment:
                    IntegrationResponse.FindBoletoPaymentDetailsResponse findBoletoPaymentDetailsResponse = accountIntegrationService.FindBoletoPaymentDetails(integrationRequest);
                    result = _mapper.Map(findBoletoPaymentDetailsResponse);
                    break;
                case OperationType.GAREPayment:
                    IntegrationResponse.FindGAREPaymentDetailsResponse findGAREPaymentDetailsResponse = accountIntegrationService.FindGAREPaymentDetails(integrationRequest);
                    result = _mapper.Map(findGAREPaymentDetailsResponse);
                    break;
                case OperationType.DARJPayment:
                    IntegrationResponse.FindDARJPaymentDetailsResponse findDARJPaymentDetailsResponse = accountIntegrationService.FindDARJPaymentDetails(integrationRequest);
                    result = _mapper.Map(findDARJPaymentDetailsResponse);
                    break;
                case OperationType.FGTSPayment:
                    IntegrationResponse.FindFGTSPaymentDetailsResponse findFGTSPaymentDetailsResponse = accountIntegrationService.FindFGTSPaymentDetails(integrationRequest);
                    result = _mapper.Map(findFGTSPaymentDetailsResponse);
                    break;
                case OperationType.PurchaseTopUp:
                    IntegrationResponse.FindTopUpDetailsResponse findTopUpDetailsResponse = accountIntegrationService.FindTopUpDetails(integrationRequest);
                    result = _mapper.Map(findTopUpDetailsResponse);
                    break;
                case OperationType.PixOut:
                    IntegrationResponse.FindPixDetailsResponse findPixOutDetailsResponse = accountIntegrationService.FindPixTransferDetails(integrationRequest);
                    result = _mapper.Map(findPixOutDetailsResponse);
                    break;
                case OperationType.PixIn:
                    IntegrationResponse.FindPixDetailsResponse findPixInDetailsResponse = accountIntegrationService.FindPixTransferDetails(integrationRequest);
                    result = _mapper.Map(findPixInDetailsResponse);
                    break;
            }

            return result;
        }

        public FindBankStatementMonthlySummaryResult FindBankStatementMonthlySummary(FindBankStatementMonthlySummaryRequest findBankStatementMonthlySummaryRequest)
        {
            _validator.Validate(findBankStatementMonthlySummaryRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(findBankStatementMonthlySummaryRequest.AccountId);

            IntegrationRequest.FindBankStatementMonthlySummaryRequest integrationRequest = _mapper.Map(findBankStatementMonthlySummaryRequest.DateMonthly, account);

            IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();
            IntegrationResponse.FindBankStatementMonthlySummaryResponse findBankStatementMonthlySummaryResponse = accountIntegrationService.FindBankStatementMonthlySummary(integrationRequest);

            FindBankStatementMonthlySummaryResult result = _mapper.Map<FindBankStatementMonthlySummaryResult>(findBankStatementMonthlySummaryResponse);
            return result;
        }

        public FindAccountListResult FindAccountListByTaxId(FindAccountListByTaxIdRequest findAccountsByTaxIdRequest)
        {
            _validator.Validate(findAccountsByTaxIdRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(findAccountsByTaxIdRequest.AccountId);
            List<Account> accountList = accountRepository.GetByTaxIdAndCompanyId(findAccountsByTaxIdRequest.TaxId, account.CompanyId).ToList();

            accountList.Remove(accountList.SingleOrDefault(x => x.AccountId == findAccountsByTaxIdRequest.AccountId));

            FindAccountListResult result = _mapper.Map(accountList);
            return result;
        }

        public void FixingChange(FixingChangeRequest fixingChangeRequest)
        {
            _accountRepositoryFactory.Create().UpdateUserAccountFixing(fixingChangeRequest.AccountId, fixingChangeRequest.UserId, fixingChangeRequest.IsFixed);
        }

        public FindAccountByPhoneNumberResult FindAccountByPhoneNumber(FindAccountByPhoneNumberRequest findAccountByPhoneNumberRequest)
        {
            IAccountRepository accountRepository = _accountRepositoryFactory.Create();

            Account regularAccount = accountRepository.GetByPhoneNumberAndCompanyId(findAccountByPhoneNumberRequest.PhoneNumber, findAccountByPhoneNumberRequest.CompanyId);

            if (regularAccount != null && regularAccount.AccountId == findAccountByPhoneNumberRequest.AccountId)
                throw new OsbBusinessException(AccountExcMsg.EXC0015);

            FindAccountByPhoneNumberResult result = _mapper.MapAccount(regularAccount);

            return result;
        }

        public Account FindAccountByAccountKey(string accountKey)
        {
            IAccountRepository accountRepository = _accountRepositoryFactory.Create();

            Account account = accountRepository.GetByAccountKey(accountKey);

            return account;
        }

        public ChangeAccountOperationLimitResult ChangeAccountOperationLimit(ChangeAccountOperationLimitRequest changeAccountOperationLimitRequest)
        {
            _validator.Validate(changeAccountOperationLimitRequest);

            try
            {
                IntegrationRequest.ChangeAccountOperationLimitRequest integrationRequest = _mapper.Map(changeAccountOperationLimitRequest);

                IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();
                IntegrationResponse.ChangeAccountOperationLimitResponse changeAccountOperationLimitResponse = accountIntegrationService.ChangeAccountOperationLimit(integrationRequest);

                ChangeAccountOperationLimitResult result = _mapper.Map<ChangeAccountOperationLimitResult>(changeAccountOperationLimitResponse);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public FindAccountOperationLimitResult FindAccountOperationLimit(FindAccountOperationLimitRequest findAccountOperationLimitRequest)
        {
            _validator.Validate(findAccountOperationLimitRequest);

            try
            {
                IntegrationRequest.FindAccountOperationLimitRequest integrationRequest = _mapper.Map(findAccountOperationLimitRequest);

                IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();
                IntegrationResponse.FindAccountOperationLimitResponse findAccountOperationLimitResponse = accountIntegrationService.FindAccountOperationLimit(integrationRequest);

                FindAccountOperationLimitResult result = _mapper.Map<FindAccountOperationLimitResult>(findAccountOperationLimitResponse);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public FindAccountOperationLimitListResult FindAccountOperationLimitList(FindAccountOperationLimitListRequest findAccountOperationLimitListRequest)
        {
            _validator.Validate(findAccountOperationLimitListRequest);

            try
            {
                IntegrationRequest.FindAccountOperationLimitListRequest integrationRequest = _mapper.Map(findAccountOperationLimitListRequest);

                IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();
                IntegrationResponse.FindAccountOperationLimitListResponse findAccountOperationLimitListResponse = accountIntegrationService.FindAccountOperationLimitList(integrationRequest);

                FindAccountOperationLimitListResult result = _mapper.Map<FindAccountOperationLimitListResult>(findAccountOperationLimitListResponse);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public FindAccountOperationResult FindAccountOperation(FindAccountOperationRequest findAccountOperationRequest)
        {
            _validator.Validate(findAccountOperationRequest);

            IOperationRepository operationRepository = _operationRepositoryFactory.Create();
            Operation operation = operationRepository.GetByIdAndType(findAccountOperationRequest.OperationId, findAccountOperationRequest.OperationType);

            if (operation == null)
                throw new OsbBusinessException(AccountExcMsg.EXC0023);

            FindAccountOperationResult findAccountOperationResult = _mapper.Map(operation);

            return findAccountOperationResult;
        }
    }
}