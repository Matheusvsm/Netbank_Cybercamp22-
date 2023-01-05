using System.Collections.Generic;
using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    class LimitedAccountMapper
    {
        public BusinessRequest.LimitedAccountRequest Map(LimitedAccountRequest limitedAccountRequest, object companyId)
        {
            BusinessRequest.LimitedAccountRequest businessLimitedAccountRequest = new BusinessRequest.LimitedAccountRequest
            {
                CompanyId = (long)companyId,
                Name = limitedAccountRequest.Name,
                PhoneNumber = limitedAccountRequest.PhoneNumber,
                TaxId = Formatter.RemoveMaskFromTaxId(limitedAccountRequest.TaxId),
                Mail = limitedAccountRequest.Mail,
                Nickname = limitedAccountRequest.Nickname,
                Bank = limitedAccountRequest.Bank,
                BankBranch = limitedAccountRequest.BankBranch,
                BankAccount = limitedAccountRequest.BankAccount,
                BankAccountDigit = limitedAccountRequest.BankAccountDigit,
                BirthDate = limitedAccountRequest.BirthDate,
                Password = limitedAccountRequest.Password,
                TradingName = limitedAccountRequest.TradingName,
                LegalName = limitedAccountRequest.LegalName,
                ConstitutionDate = limitedAccountRequest.ConstitutionDate
            };

            if (limitedAccountRequest.Persons != null)
            {
                businessLimitedAccountRequest.Persons = new List<BusinessRequest.LimitedPersonRequest>();

                foreach (LimitedPersonRequest person in limitedAccountRequest.Persons)
                    businessLimitedAccountRequest.Persons.Add(Map(person));

            }

            return businessLimitedAccountRequest;
        }

        private BusinessRequest.LimitedPersonRequest Map(LimitedPersonRequest limitedPersonRequest)
        {
            return new BusinessRequest.LimitedPersonRequest
            {
                Name = limitedPersonRequest.Name,
                TaxNumber = limitedPersonRequest.TaxNumber,
                Mail = limitedPersonRequest.Mail,
                Phone = limitedPersonRequest.Phone,
                PersonRoleType = limitedPersonRequest.PersonRoleType,
                BirthDate = limitedPersonRequest.BirthDate
            };
        }
    }
}