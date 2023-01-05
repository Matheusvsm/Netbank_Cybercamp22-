using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using IntegrationService = Osb.Core.Platform.Integration.Service.Fitbank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.Fitbank.Models.Request;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Fitbank.Models.Response;

namespace Osb.Core.Platform.Business.Service
{
    public class NewAccountService : INewAccountService
    {
        private readonly NewAccountValidator _validator;
        private readonly NewAccountMapper _mapper;
        private readonly Settings _settings;
        private readonly INewAccountServiceFactory _newAccountIntegrationServiceFactory;
        private readonly INewAccountRepositoryFactory _newAccountRepositoryFactory;
        private readonly INewAccountAddressRepositoryFactory _newAccountAddressRepositoryFactory;
        private readonly INewAccountPersonRepositoryFactory _newAccountPersonRepositoryFactory;
        private readonly INewAccountPersonDocumentRepositoryFactory _newAccountPersonDocumentRepositoryFactory;
        private IConnectionFactory _connectionFactory;

        public NewAccountService(
            INewAccountServiceFactory newAccountIntegrationServiceFactory,
            INewAccountRepositoryFactory newAccountRepositoryFactory,
            INewAccountAddressRepositoryFactory newAccountAddressRepositoryFactory,
            INewAccountPersonRepositoryFactory newAccountPersonRepositoryFactory,
            INewAccountPersonDocumentRepositoryFactory newAccountPersonDocumentRepositoryFactory,
            Settings settings,
            IConnectionFactory connectionFactory
        )
        {
            _newAccountIntegrationServiceFactory = newAccountIntegrationServiceFactory;
            _newAccountRepositoryFactory = newAccountRepositoryFactory;
            _newAccountAddressRepositoryFactory = newAccountAddressRepositoryFactory;
            _newAccountPersonRepositoryFactory = newAccountPersonRepositoryFactory;
            _newAccountPersonDocumentRepositoryFactory = newAccountPersonDocumentRepositoryFactory;
            _mapper = new NewAccountMapper();
            _validator = new NewAccountValidator();
            _settings = settings;
            _connectionFactory = connectionFactory;
        }

        public void Save(NewAccountRequest newAccountRequest)
        {
            _validator.Validate(newAccountRequest);

            TransactionScope transactionScope = _connectionFactory.CreateTransaction();

            try
            {
                INewAccountRepository newAccountRepository = _newAccountRepositoryFactory.Create();
                INewAccountAddressRepository newAccountAddressRepository = _newAccountAddressRepositoryFactory.Create();
                INewAccountPersonRepository newAccountPersonRepository = _newAccountPersonRepositoryFactory.Create();
                INewAccountPersonDocumentRepository newAccountPersonDocumentRepository = _newAccountPersonDocumentRepositoryFactory.Create();

                NewAccount newAccount = NewAccount.Create(newAccountRequest.CompanyId, newAccountRequest.TaxId, newAccountRequest.PersonName,
                                                        newAccountRequest.PhoneNumber, newAccountRequest.Mail, newAccountRequest.Nickname,
                                                        newAccountRequest.BirthDate, newAccountRequest.MotherFullName, newAccountRequest.FatherFullName,
                                                        newAccountRequest.Nationality, newAccountRequest.BirthCity, newAccountRequest.BirthState,
                                                        newAccountRequest.Gender, newAccountRequest.MaritalStatus, newAccountRequest.SpouseName,
                                                        newAccountRequest.Occupation, newAccountRequest.CompanyType, newAccountRequest.CompanyActivity,
                                                        newAccountRequest.ConstitutionDate, newAccountRequest.PubliclyExposedPerson,
                                                        newAccountRequest.CheckPendingTransfers, newAccountRequest.IdentityDocument,
                                                        newAccountRequest.Bank, newAccountRequest.BankBranch, newAccountRequest.BankAccount,
                                                        newAccountRequest.BankAccountDigit, _settings.UserDefault
                );

                NewAccount newAccountResult = newAccountRepository.Save(newAccount, transactionScope);

                foreach (NewAccountAddressRequest address in newAccountRequest.Addresses)
                {
                    NewAccountAddress newAccountAddress = NewAccountAddress.Create(newAccountResult.NewAccountId, address.AddressLine, address.AddressLine2,
                                                                                address.ZipCode, address.Neighborhood, address.CityCode, address.CityName,
                                                                                address.State, address.AddressType, address.Country, address.Complement,
                                                                                _settings.UserDefault
                    );

                    newAccountAddressRepository.Save(newAccountAddress, transactionScope);
                }

                foreach (NewAccountPersonDocumentRequest document in newAccountRequest.Documents)
                {
                    NewAccountPersonDocument newAccountPersonDocument = NewAccountPersonDocument.Create(newAccountResult.NewAccountId, null, document.DocumentFile,
                                                                                                        document.DocumentFormat, document.DocumentName, document.DocumentType,
                                                                                                        document.Description, document.ExpirationDate, _settings.UserDefault
                    );

                    newAccountPersonDocumentRepository.Save(newAccountPersonDocument, transactionScope);
                }

                foreach (NewAccountPersonRequest person in newAccountRequest.Persons)
                {
                    NewAccountPerson newAccountPerson = NewAccountPerson.Create(newAccountResult.NewAccountId, person.TaxId, person.Name, person.Mail, person.Occupation,
                                                                                person.Phone, person.PersonRoleType, person.MotherFullName, person.FatherFullName,
                                                                                person.Nationality, person.BirthCity, person.BirthState, person.Gender, person.MaritalStatus,
                                                                                person.SpouseName, person.IdentityDocument, person.CompanyType, person.CompanyActivity,
                                                                                person.ConstitutionDate, person.CheckPendingTransfers, person.BirthDate, person.PersonName,
                                                                                person.PhoneNumber, person.Nickname, person.PubliclyExposedPerson, _settings.UserDefault
                    );

                    NewAccountPerson newAccountPersonResult = newAccountPersonRepository.Save(newAccountPerson, transactionScope);

                    foreach (NewAccountPersonDocumentRequest document in person.PersonDocuments)
                    {
                        NewAccountPersonDocument newAccountPersonDocument = NewAccountPersonDocument.Create(null, newAccountPersonResult.NewAccountPersonId, document.DocumentFile,
                                                                                                            document.DocumentFormat, document.DocumentName, document.DocumentType,
                                                                                                            document.Description, document.ExpirationDate, _settings.UserDefault
                        );

                        newAccountPersonDocumentRepository.Save(newAccountPersonDocument, transactionScope);
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

        public void GenerateNewAccount(NewAccount newAccount)
        {
            INewAccountRepository newAccountRepository = _newAccountRepositoryFactory.Create();
            INewAccountAddressRepository newAccountAddressRepository = _newAccountAddressRepositoryFactory.Create();
            INewAccountPersonRepository newAccountPersonRepository = _newAccountPersonRepositoryFactory.Create();
            INewAccountPersonDocumentRepository newAccountPersonDocumentRepository = _newAccountPersonDocumentRepositoryFactory.Create();

            IntegrationRequest.NewAccountRequest integrationRequest = _mapper.Map(newAccount);

            integrationRequest.Addresses = new List<IntegrationRequest.NewAccountAddressRequest>();
            integrationRequest.Documents = new List<IntegrationRequest.NewAccountPersonDocumentRequest>();
            integrationRequest.Persons = new List<IntegrationRequest.NewAccountPersonRequest>();

            IEnumerable<NewAccountAddress> addresses = newAccountAddressRepository.GetByNewAccountId(newAccount.NewAccountId);
            foreach (NewAccountAddress address in addresses)
                integrationRequest.Addresses.Add(_mapper.Map(address));

            IEnumerable<NewAccountPersonDocument> documents = newAccountPersonDocumentRepository.GetByNewAccountId(newAccount.NewAccountId);
            foreach (NewAccountPersonDocument document in documents)
                integrationRequest.Documents.Add(_mapper.Map(document));

            IEnumerable<NewAccountPerson> persons = newAccountPersonRepository.GetByNewAccountId(newAccount.NewAccountId);
            foreach (NewAccountPerson person in persons)
            {
                IEnumerable<NewAccountPersonDocument> personDocuments = newAccountPersonDocumentRepository.GetByNewAccountPersonId(person.NewAccountPersonId);
                integrationRequest.Persons.Add(_mapper.Map(person, personDocuments));
            }

            IntegrationService.INewAccountService newAccountIntergrationService = _newAccountIntegrationServiceFactory.Create();
            NewAccountResponse newAccountResponse = newAccountIntergrationService.NewAccount(integrationRequest);

            if (newAccountResponse.ResponseStatus)
                newAccount.Status = NewAccountStatus.Registered;
            else
            {
                newAccount.Attempts += 1;

                if (newAccount.Attempts >= _settings.Attempts)
                    newAccount.Status = NewAccountStatus.Error;
            }

            newAccountRepository.Update(newAccount);
        }

        public void Update(NewAccount newAccount)
        {
            INewAccountRepository newAccountRepository = _newAccountRepositoryFactory.Create();

            newAccountRepository.Update(newAccount);
        }

        public IEnumerable<NewAccount> FindNewAccountByStatus(NewAccountStatus status)
        {
            INewAccountRepository newAccountRepository = _newAccountRepositoryFactory.Create();
            IEnumerable<NewAccount> newAccountList = newAccountRepository.GetByStatus(status);

            return newAccountList;
        }
    }
}