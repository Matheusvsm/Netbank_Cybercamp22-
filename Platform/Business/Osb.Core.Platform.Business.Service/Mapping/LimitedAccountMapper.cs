using Osb.Core.Platform.Business.Entity.Models;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class LimitedAccountMapper : Mapper
    {
        public IntegrationRequest.LimitedAccountRequest Map(LimitedAccount limitedAccount)
        {
            return new IntegrationRequest.LimitedAccountRequest
            {
                CompanyId = limitedAccount.CompanyId,
                Name = limitedAccount.Name,
                PhoneNumber = limitedAccount.PhoneNumber,
                TaxId = limitedAccount.TaxId,
                Mail = limitedAccount.Mail,
                Nickname = limitedAccount.Nickname,
                Bank = limitedAccount.Bank,
                BankBranch = limitedAccount.BankBranch,
                BankAccount = limitedAccount.BankAccount,
                BankAccountDigit = limitedAccount.BankAccountDigit,
                BirthDate = limitedAccount.BirthDate,
                TradingName = limitedAccount.TradingName,
                LegalName = limitedAccount.LegalName,
                ConstitutionDate = limitedAccount.ConstitutionDate
            };
        }

        public IntegrationRequest.LimitedPersonRequest Map(LimitedPerson limitedPerson)
        {
            return new IntegrationRequest.LimitedPersonRequest
            {
                Name = limitedPerson.Name,
                TaxNumber = limitedPerson.TaxNumber,
                Mail = limitedPerson.Mail,
                Phone = limitedPerson.Phone,
                PersonRoleType = limitedPerson.PersonRoleType,
                BirthDate = limitedPerson.BirthDate
            };
        }
    }
}