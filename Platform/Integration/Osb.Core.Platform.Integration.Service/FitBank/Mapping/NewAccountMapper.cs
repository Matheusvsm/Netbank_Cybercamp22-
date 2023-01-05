using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.Fitbank.Models.Request;
using Osb.Core.Platform.Integration.Service.Mapping;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;

namespace Osb.Core.Platform.Integration.Service.Fitbank.Mapping
{
    public class NewAccountMapper : Mapper
    {
        public ExternalRequest Map(NewAccountRequest newAccountRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), newAccountRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = newAccountRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PersonName = newAccountRequest.PersonName,
                    PhoneNumber = newAccountRequest.PhoneNumber,
                    TaxNumber = newAccountRequest.TaxId,
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
                    BankAccountDigit = newAccountRequest.BankAccountDigit,
                    Addresses = newAccountRequest.Addresses,
                    Documents = newAccountRequest.Documents,
                    Persons = newAccountRequest.Persons
                }
            };
        }
    }
}