using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Service.Mapping;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class AccountMapper : Mapper
    {
        public ExternalRequest Map(
            FindAccountBalanceRequest getBalanceRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                getBalanceRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = getBalanceRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = getBalanceRequest.TaxId,
                    Bank = getBalanceRequest.Bank,
                    BankAccount = getBalanceRequest.BankAccount,
                    BankAccountDigit = getBalanceRequest.BankAccountDigit,
                    BankBranch = getBalanceRequest.BankBranch,
                    OnlyBalance = true
                }
            };
        }

        public ExternalRequest Map(FindBankStatementRequest findBankStatementRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findBankStatementRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findBankStatementRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    StartDate = findBankStatementRequest.StartDate,
                    EndDate = findBankStatementRequest.EndDate,
                    OperationType = findBankStatementRequest.OperationType,
                    Tags = findBankStatementRequest.Tags,
                    TaxNumber = findBankStatementRequest.TaxId,
                    Bank = findBankStatementRequest.Bank,
                    BankAccount = findBankStatementRequest.BankAccount,
                    BankAccountDigit = findBankStatementRequest.BankAccountDigit,
                    BankBranch = findBankStatementRequest.BankBranch,
                    EntryClassificationType = findBankStatementRequest.TransactionType != null ? Enum.GetName(typeof(TransactionType), findBankStatementRequest.TransactionType) : null
                }
            };
        }


        public ExternalRequest Map(FindBankStatementDetailsRequest findBankStatementDetailsRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), findBankStatementDetailsRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findBankStatementDetailsRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    DocumentNumber = findBankStatementDetailsRequest.ExternalIdentifier,
                    TaxNumber = findBankStatementDetailsRequest.TaxId,
                    Bank = findBankStatementDetailsRequest.Bank,
                    BankBranch = findBankStatementDetailsRequest.BankBranch,
                    BankAccount = findBankStatementDetailsRequest.BankAccount,
                    BankAccountDigit = findBankStatementDetailsRequest.BankAccountDigit
                }
            };
        }

        public ExternalRequest Map(FindBankStatementMonthlySummaryRequest findMonthlyAccountMovementsRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), findMonthlyAccountMovementsRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findMonthlyAccountMovementsRequest.Method,
                    TaxNumber = findMonthlyAccountMovementsRequest.TaxId,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    Bank = findMonthlyAccountMovementsRequest.Bank,
                    BankBranch = findMonthlyAccountMovementsRequest.BankBranch,
                    BankAccount = findMonthlyAccountMovementsRequest.BankAccount,
                    BankAccountDigit = findMonthlyAccountMovementsRequest.BankAccountDigit,
                    DateMonthly = findMonthlyAccountMovementsRequest.DateMonthly
                }
            };
        }

        public FindBankStatementMonthlySummaryResponse Map(ExternalFindBankStatementMonthlySummaryResponse externalFindMonthlyAccountMovementsResponse)
        {
            return new FindBankStatementMonthlySummaryResponse
            {
                MoneyInputValue = externalFindMonthlyAccountMovementsResponse.FinancesMonthly.MoneyInputValue,
                MoneyOutputValue = externalFindMonthlyAccountMovementsResponse.FinancesMonthly.MoneyOutputValue
            };
        }

        public ExternalRequest Map(ChangeAccountOperationLimitRequest changeAccountOperationLimitRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(AuthorizationMapper.Map(companyAuthentication), changeAccountOperationLimitRequest.Headers);

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    Method = changeAccountOperationLimitRequest.Method,
                    TaxNumber = changeAccountOperationLimitRequest.TaxId,
                    Bank = changeAccountOperationLimitRequest.Bank,
                    BankBranch = changeAccountOperationLimitRequest.BankBranch,
                    BankAccount = changeAccountOperationLimitRequest.BankAccount,
                    BankAccountDigit = changeAccountOperationLimitRequest.BankAccountDigit,
                    OperationType = changeAccountOperationLimitRequest.OperationType,
                    Type = changeAccountOperationLimitRequest.AccountOperationLimitType,
                    SubType = changeAccountOperationLimitRequest.AccountOperationLimitSubType,
                    MinLimitValue = changeAccountOperationLimitRequest.MinLimitValue,
                    MaxLimitValue = changeAccountOperationLimitRequest.MaxLimitValue
                }
            };
        }

        public ExternalRequest Map(FindAccountOperationLimitRequest findAccountOperationLimitRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findAccountOperationLimitRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findAccountOperationLimitRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = findAccountOperationLimitRequest.TaxId,
                    Bank = findAccountOperationLimitRequest.Bank,
                    BankBranch = findAccountOperationLimitRequest.BankBranch,
                    BankAccount = findAccountOperationLimitRequest.BankAccount,
                    BankAccountDigit = findAccountOperationLimitRequest.BankAccountDigit,
                    OperationType = findAccountOperationLimitRequest.OperationType,
                    Type = findAccountOperationLimitRequest.AccountOperationLimitType,
                    SubType = findAccountOperationLimitRequest.AccountOperationLimitSubType,
                }
            };
        }

        public ExternalRequest Map(FindAccountOperationLimitListRequest findAccountOperationLimitListRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findAccountOperationLimitListRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findAccountOperationLimitListRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = findAccountOperationLimitListRequest.TaxId,
                    Bank = findAccountOperationLimitListRequest.Bank,
                    BankBranch = findAccountOperationLimitListRequest.BankBranch,
                    BankAccount = findAccountOperationLimitListRequest.BankAccount,
                    BankAccountDigit = findAccountOperationLimitListRequest.BankAccountDigit,
                    OperationType = findAccountOperationLimitListRequest.OperationType,
                    Type = findAccountOperationLimitListRequest.AccountOperationLimitType,
                    SubType = findAccountOperationLimitListRequest.AccountOperationLimitSubType,
                    Index = findAccountOperationLimitListRequest.Index,
                    PageSize = Int32.MaxValue,
                    ColumnOrder = findAccountOperationLimitListRequest.ColumnOrder
                }
            };
        }
    }
}