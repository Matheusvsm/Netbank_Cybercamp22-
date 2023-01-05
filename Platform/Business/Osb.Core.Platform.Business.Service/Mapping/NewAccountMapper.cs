using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.Fitbank.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class NewAccountMapper : Mapper
    {
        public IntegrationRequest.NewAccountRequest Map(NewAccount newAccount)
        {
            return new IntegrationRequest.NewAccountRequest
            {
               CompanyId = newAccount.CompanyId,
               PersonName = newAccount.PersonName,
               PhoneNumber = newAccount.PhoneNumber,
               TaxId = newAccount.TaxId,
               Mail = newAccount.Mail,
               Nickname = newAccount.Nickname,
               PubliclyExposedPerson = newAccount.PubliclyExposedPerson,
               BirthDate = newAccount.BirthDate,
               MotherFullName = newAccount.MotherFullName,
               FatherFullName = newAccount.FatherFullName,
               Nationality = newAccount.Nationality,
               BirthCity = newAccount.BirthCity,
               BirthState = newAccount.BirthState,
               Gender = newAccount.Gender,
               MaritalStatus = newAccount.MaritalStatus,
               SpouseName = newAccount.SpouseName,
               Occupation = newAccount.Occupation,
               IdentityDocument = newAccount.IdentityDocument,
               CompanyType = newAccount.CompanyType,
               CompanyActivity = newAccount.CompanyActivity,
               ConstitutionDate = newAccount.ConstitutionDate,
               CheckPendingTransfers = newAccount.CheckPendingTransfers,
               Bank = newAccount.Bank,
               BankBranch = newAccount.BankBranch,
               BankAccount = newAccount.BankAccount,
               BankAccountDigit = newAccount.BankAccountDigit,
               UserId = newAccount.CreationUserId
            };
        }

        public IntegrationRequest.NewAccountAddressRequest Map(NewAccountAddress newAccountAddress)
        {
            return new IntegrationRequest.NewAccountAddressRequest
            {
                AddressLine = newAccountAddress.AddressLine,
                AddressLine2 = newAccountAddress.AddressLine2,
                ZipCode = newAccountAddress.ZipCode,
                Neighborhood = newAccountAddress.Neighborhood,
                CityCode = newAccountAddress.CityCode,
                CityName = newAccountAddress.CityName,
                State = newAccountAddress.State,
                AddressType = newAccountAddress.AddressType,
                Country = newAccountAddress.Country,
                Complement = newAccountAddress.Complement
            };
        }

        public IntegrationRequest.NewAccountPersonRequest Map(NewAccountPerson newAccountPerson, IEnumerable<NewAccountPersonDocument> documents)
        {
            IntegrationRequest.NewAccountPersonRequest personRequest = new IntegrationRequest.NewAccountPersonRequest
            {
                TaxNumber = newAccountPerson.TaxId,
                Name = newAccountPerson.Name,
                Mail = newAccountPerson.Mail,
                Occupation = newAccountPerson.Occupation,
                Phone = newAccountPerson.Phone,
                PersonRoleType = newAccountPerson.PersonRoleType,
                MotherFullName = newAccountPerson.MotherFullName,
                FatherFullName = newAccountPerson.FatherFullName,
                Nationality = newAccountPerson.Nationality,
                BirthCity = newAccountPerson.BirthCity,
                BirthState = newAccountPerson.BirthState,
                Gender = newAccountPerson.Gender,
                MaritalStatus = newAccountPerson.MaritalStatus,
                SpouseName = newAccountPerson.SpouseName,
                IdentityDocument = newAccountPerson.IdentityDocument,
                CompanyType = newAccountPerson.CompanyType,
                CompanyActivity = newAccountPerson.CompanyActivity,
                ConstitutionDate = newAccountPerson.ConstitutionDate,
                CheckPendingTransfers = newAccountPerson.CheckPendingTransfers,
                BirthDate = newAccountPerson.BirthDate,
                PersonName = newAccountPerson.PersonName,
                PhoneNumber = newAccountPerson.PhoneNumber,
                Nickname = newAccountPerson.Nickname,
                PubliclyExposedPerson = newAccountPerson.PubliclyExposedPerson
            };

            personRequest.PersonDocuments = new List<IntegrationRequest.NewAccountPersonDocumentRequest>();

            foreach(NewAccountPersonDocument document in documents)
                personRequest.PersonDocuments.Add(Map(document));

            return personRequest;
        }

        public IntegrationRequest.NewAccountPersonDocumentRequest Map(NewAccountPersonDocument newAccountPersonDocument)
        {
            return new IntegrationRequest.NewAccountPersonDocumentRequest
            {
                DocumentFile = newAccountPersonDocument.DocumentFile,
                DocumentFormat = newAccountPersonDocument.DocumentFormat,
                DocumentName = newAccountPersonDocument.DocumentName,
                DocumentType = newAccountPersonDocument.DocumentType,
                Description = newAccountPersonDocument.Description,
                ExpirationDate = newAccountPersonDocument.ExpirationDate
            };
        }
    }
}