using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using IntegrationService = Osb.Core.Platform.Integration.Service.Fitbank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Common.Entity;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Util.Security;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Service
{
    public class LimitedAccountService : ILimitedAccountService
    {
        private readonly LimitedAccountValidator _validator;
        private readonly LimitedAccountMapper _mapper;
        private readonly ILimitedAccountServiceFactory _limitedAccountIntegrationServiceFactory;
        private readonly ILimitedAccountRepositoryFactory _limitedAccountRepositoryFactory;
        private readonly ILimitedPersonRepositoryFactory _limitedPersonRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private IConnectionFactory _connectionFactory;
        private readonly Settings _settings;

        public LimitedAccountService(
            ILimitedAccountServiceFactory limitedAccountIntegrationServiceFactory,
            ILimitedAccountRepositoryFactory limitedAccountRepositoryFactory,
            ILimitedPersonRepositoryFactory limitedPersonRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IConnectionFactory connectionFactory,
            Settings settings
        )
        {
            _limitedAccountIntegrationServiceFactory = limitedAccountIntegrationServiceFactory;
            _limitedAccountRepositoryFactory = limitedAccountRepositoryFactory;
            _limitedAccountRepositoryFactory = limitedAccountRepositoryFactory;
            _limitedPersonRepositoryFactory = limitedPersonRepositoryFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _connectionFactory = connectionFactory;
            _settings = settings;
            _mapper = new LimitedAccountMapper();
            _validator = new LimitedAccountValidator();
        }

        public void Save(LimitedAccountRequest limitedAccountRequest)
        {
            _validator.Validate(limitedAccountRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                LimitedAccount limitedAccount = LimitedAccount.Create(limitedAccountRequest.CompanyId,
                                                                        limitedAccountRequest.Name,
                                                                        limitedAccountRequest.PhoneNumber,
                                                                        limitedAccountRequest.TaxId,
                                                                        limitedAccountRequest.Mail,
                                                                        limitedAccountRequest.Nickname,
                                                                        limitedAccountRequest.Bank,
                                                                        limitedAccountRequest.BankBranch,
                                                                        limitedAccountRequest.BankAccount,
                                                                        limitedAccountRequest.BankAccountDigit,
                                                                        limitedAccountRequest.BirthDate,
                                                                        limitedAccountRequest.TradingName,
                                                                        limitedAccountRequest.LegalName,
                                                                        limitedAccountRequest.ConstitutionDate,
                                                                        _settings.UserDefault);

                limitedAccount.Salt = SHA512Provider.GenerateSalt();

                limitedAccount.Password = SHA512Provider.Encrypt
                (
                    limitedAccountRequest.Password,
                    limitedAccount.Salt
                );

                ILimitedAccountRepository limitedAccountRepository = _limitedAccountRepositoryFactory.Create();

                LimitedAccount limitedAccountResult = limitedAccountRepository.Save(limitedAccount, transactionScope);

                if (limitedAccountRequest.Persons != null)
                {
                    foreach (LimitedPersonRequest person in limitedAccountRequest.Persons)
                    {
                        LimitedPerson limitedPerson = LimitedPerson.Create(limitedAccountResult.LimitedAccountId,
                                                                            person.Name,
                                                                            person.TaxNumber,
                                                                            person.Mail,
                                                                            person.Phone,
                                                                            person.PersonRoleType,
                                                                            person.BirthDate,
                                                                            _settings.UserDefault);

                        ILimitedPersonRepository limitedPersonRepository = _limitedPersonRepositoryFactory.Create();

                        limitedPersonRepository.Save(limitedPerson, transactionScope);
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

        public void GenerateLimitedAccount(LimitedAccount limitedAccount)
        {
            ILimitedAccountRepository limitedAccountRepository = _limitedAccountRepositoryFactory.Create();
            ILimitedPersonRepository limitedPersonRepository = _limitedPersonRepositoryFactory.Create();

            IntegrationRequest.LimitedAccountRequest integrationRequest = _mapper.Map(limitedAccount);

            integrationRequest.Persons = new List<IntegrationRequest.LimitedPersonRequest>();

            IEnumerable<LimitedPerson> limitedPersons = limitedPersonRepository.GetByLimitedAccountId(limitedAccount.LimitedAccountId);

            foreach (LimitedPerson limitedPerson in limitedPersons)
                integrationRequest.Persons.Add(_mapper.Map(limitedPerson));

            IntegrationService.ILimitedAccountService limitedAccountIntegrationService = _limitedAccountIntegrationServiceFactory.Create();

            IntegrationResponse.LimitedAccountResponse limitedAccountResponse = limitedAccountIntegrationService.LimitedAccount(integrationRequest);

            if (limitedAccountResponse.ResponseStatus)
            {
                limitedAccount.Status = LimitedAccountStatus.PendingUser;
                limitedAccount.AccountKey = limitedAccountResponse.AccountKey;
            }
            else
            {
                limitedAccount.Attempts += 1;

                if (limitedAccount.Attempts >= _settings.Attempts)
                    limitedAccount.Status = LimitedAccountStatus.Error;
            }

            limitedAccountRepository.Update(limitedAccount);
        }

        public IEnumerable<LimitedAccount> FindLimitedAccountListByStatus(LimitedAccountStatus status)
        {
            ILimitedAccountRepository limitedAccountRepository = _limitedAccountRepositoryFactory.Create();
            IEnumerable<LimitedAccount> limitedAccountList = limitedAccountRepository.GetListByStatus(status);

            return limitedAccountList;
        }

        public void Update(LimitedAccount limitedAccount, TransactionScope transctionScope = null)
        {
            ILimitedAccountRepository limitedAccountRepository = _limitedAccountRepositoryFactory.Create();

            limitedAccountRepository.Update(limitedAccount);
        }
    }
}