using System.Collections.Generic;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class NewAccountMapper
    {
        public BusinessRequest.NewAccountRequest Map(NewAccountRequest newAccountRequest, object companyId)
        {
            BusinessRequest.NewAccountRequest businessNewAccountRequest = new BusinessRequest.NewAccountRequest
            {
                CompanyId = (long)companyId,
                PersonName = newAccountRequest.PersonName,
                PhoneNumber = newAccountRequest.PhoneNumber,
                TaxId = Formatter.RemoveMaskFromTaxId(newAccountRequest.TaxId),
                Mail = newAccountRequest.Mail,
                Nickname = newAccountRequest.Nickname,
                PubliclyExposedPerson = newAccountRequest.PubliclyExposedPerson,
                BirthDate = newAccountRequest.BirthDate,
                MotherFullName = newAccountRequest.MotherFullName,
                FatherFullName = newAccountRequest.FatherFullName,
                Nationality = newAccountRequest.Nationality,
                BirthCity = newAccountRequest.BirthCity,
                BirthState = newAccountRequest.BirthState,
                Gender = newAccountRequest.Gender,
                MaritalStatus = newAccountRequest.MaritalStatus,
                SpouseName = newAccountRequest.SpouseName,
                Occupation = newAccountRequest.Occupation,
                IdentityDocument = newAccountRequest.IdentityDocument,
                CompanyType = newAccountRequest.CompanyType,
                CompanyActivity = newAccountRequest.CompanyActivity,
                ConstitutionDate = newAccountRequest.ConstitutionDate,
                CheckPendingTransfers = newAccountRequest.CheckPendingTransfers,
                Bank = newAccountRequest.Bank,
                BankBranch = newAccountRequest.BankBranch,
                BankAccount = newAccountRequest.BankAccount,
                BankAccountDigit = newAccountRequest.BankAccountDigit
            };

            businessNewAccountRequest.Addresses = new List<BusinessRequest.NewAccountAddressRequest>();
            businessNewAccountRequest.Persons = new List<BusinessRequest.NewAccountPersonRequest>();
            businessNewAccountRequest.Documents = new List<BusinessRequest.NewAccountPersonDocumentRequest>();

            foreach (NewAccountAddressRequest address in newAccountRequest.Addresses)
                businessNewAccountRequest.Addresses.Add(Map(address));

            foreach (NewAccountPersonRequest person in newAccountRequest.Persons)
                businessNewAccountRequest.Persons.Add(Map(person));

            foreach (NewAccountPersonDocumentRequest document in newAccountRequest.Documents)
                businessNewAccountRequest.Documents.Add(Map(document));

            return businessNewAccountRequest;
        }

        private BusinessRequest.NewAccountAddressRequest Map(NewAccountAddressRequest newAccountAddressRequest)
        {
            return new BusinessRequest.NewAccountAddressRequest
            {
                AddressLine = newAccountAddressRequest.AddressLine,
                AddressLine2 = newAccountAddressRequest.AddressLine2,
                ZipCode = newAccountAddressRequest.ZipCode,
                Neighborhood = newAccountAddressRequest.Neighborhood,
                CityCode = newAccountAddressRequest.CityCode,
                CityName = newAccountAddressRequest.CityName,
                State = newAccountAddressRequest.State,
                AddressType = newAccountAddressRequest.AddressType,
                Country = newAccountAddressRequest.Country,
                Complement = newAccountAddressRequest.Complement
            };
        }

        private BusinessRequest.NewAccountPersonRequest Map(NewAccountPersonRequest newAccountPersonRequest)
        {
            BusinessRequest.NewAccountPersonRequest businessNewAccountPersonRequest = new BusinessRequest.NewAccountPersonRequest
            {
                TaxId = Formatter.RemoveMaskFromTaxId(newAccountPersonRequest.TaxId),
                Name = newAccountPersonRequest.Name,
                Mail = newAccountPersonRequest.Mail,
                Occupation = newAccountPersonRequest.Occupation,
                Phone = newAccountPersonRequest.Phone,
                PersonRoleType = newAccountPersonRequest.PersonRoleType,
                MotherFullName = newAccountPersonRequest.MotherFullName,
                FatherFullName = newAccountPersonRequest.FatherFullName,
                Nationality = newAccountPersonRequest.Nationality,
                BirthCity = newAccountPersonRequest.BirthCity,
                BirthState = newAccountPersonRequest.BirthState,
                Gender = newAccountPersonRequest.Gender,
                MaritalStatus = newAccountPersonRequest.MaritalStatus,
                SpouseName = newAccountPersonRequest.SpouseName,
                IdentityDocument = newAccountPersonRequest.IdentityDocument,
                CompanyType = newAccountPersonRequest.CompanyType,
                CompanyActivity = newAccountPersonRequest.CompanyActivity,
                ConstitutionDate = newAccountPersonRequest.ConstitutionDate,
                CheckPendingTransfers = newAccountPersonRequest.CheckPendingTransfers,
                BirthDate = newAccountPersonRequest.BirthDate,
                PersonName = newAccountPersonRequest.PersonName,
                PhoneNumber = newAccountPersonRequest.PhoneNumber,
                Nickname = newAccountPersonRequest.Nickname,
                PubliclyExposedPerson = newAccountPersonRequest.PubliclyExposedPerson
            };

            businessNewAccountPersonRequest.PersonDocuments = new List<BusinessRequest.NewAccountPersonDocumentRequest>();

            foreach (NewAccountPersonDocumentRequest document in newAccountPersonRequest.PersonDocuments)
                businessNewAccountPersonRequest.PersonDocuments.Add(Map(document));

            return businessNewAccountPersonRequest;
        }

        private BusinessRequest.NewAccountPersonDocumentRequest Map(NewAccountPersonDocumentRequest newAccountPersonDocumentRequest)
        {
            return new BusinessRequest.NewAccountPersonDocumentRequest
            {
                DocumentFile = newAccountPersonDocumentRequest.DocumentFile,
                DocumentFormat = newAccountPersonDocumentRequest.DocumentFormat,
                DocumentName = newAccountPersonDocumentRequest.DocumentName,
                DocumentType = newAccountPersonDocumentRequest.DocumentType,
                Description = newAccountPersonDocumentRequest.Description,
                ExpirationDate = newAccountPersonDocumentRequest.ExpirationDate
            };
        }
    }
}