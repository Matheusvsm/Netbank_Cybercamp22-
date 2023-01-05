using System;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Mapping;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class MoneyTransferMapper : Mapper
    {
        public ExternalRequest Map(
            MoneyTransferRequest moneyTransferRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                moneyTransferRequest.Headers
            );
            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = moneyTransferRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    Identifier = moneyTransferRequest.Identifier,
                    FromTaxNumber = moneyTransferRequest.FromTaxId,
                    ToTaxNumber = moneyTransferRequest.ToTaxId,
                    ToName = moneyTransferRequest.ToName,
                    Bank = moneyTransferRequest.Bank,
                    AccountType = moneyTransferRequest.AccountType,
                    BankBranch = moneyTransferRequest.BankBranch,
                    BankAccount = moneyTransferRequest.BankAccount,
                    BankAccountDigit = moneyTransferRequest.BankAccountDigit,
                    Value = moneyTransferRequest.Value,
                    TransferDate = moneyTransferRequest.TransferDate,
                    PaymentDate = moneyTransferRequest.TransferDate,
                    Description = moneyTransferRequest.Description,
                    ExternalIdentification = moneyTransferRequest.ExternalIdentification,
                    Tags = moneyTransferRequest.Tags,
                    RateValueType = 1
                }
            };
        }

        public ExternalRequest Map(
            FindExpectedTransferDateRequest findExpectedTransferDateRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findExpectedTransferDateRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findExpectedTransferDateRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    ActualDateTransfer = findExpectedTransferDateRequest.ActualDateTransfer,
                    BankCode = findExpectedTransferDateRequest.BankCode,
                    BankingDataAccountType = findExpectedTransferDateRequest.AccountType,
                    CustomFormatDate = findExpectedTransferDateRequest.CustomFormatDate
                }
            };
        }

        public FindExpectedTransferDateResponse Map(ExternalFindExpectedTransferDateResponse externalResponse)
        {
            bool dateIsValid = DateTime.TryParse(externalResponse.ExpectedDateTransfer, out var parsedDate);

            return new FindExpectedTransferDateResponse
            {
                ExpectedTransferDate = dateIsValid ? parsedDate : null
            };
        }
    }
}