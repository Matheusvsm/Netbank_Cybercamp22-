using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Service.Mapping;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;

namespace Osb.Core.Platform.Integration.Service.Fitbank.Mapping
{
    public class LimitedAccountMapper : Mapper
    {
        public ExternalRequest Map(
            LimitedAccountRequest limitedAccountRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                limitedAccountRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = limitedAccountRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    Name = limitedAccountRequest.Name,
                    Phone = limitedAccountRequest.PhoneNumber,
                    TaxNumber = limitedAccountRequest.TaxId,
                    Mail = limitedAccountRequest.Mail,
                    Nickname = limitedAccountRequest.Nickname,
                    Bank = limitedAccountRequest.Bank,
                    BankBranch = limitedAccountRequest.BankBranch,
                    BankAccount = limitedAccountRequest.BankAccount,
                    BankAccountDigit = limitedAccountRequest.BankAccountDigit,
                    BirthDate = limitedAccountRequest.BirthDate,
                    Persons = limitedAccountRequest.Persons,
                    TradingName = limitedAccountRequest.TradingName,
                    LegalName = limitedAccountRequest.LegalName,
                    ConstitutionDate = limitedAccountRequest.ConstitutionDate
                }
            };
        }
    }
}