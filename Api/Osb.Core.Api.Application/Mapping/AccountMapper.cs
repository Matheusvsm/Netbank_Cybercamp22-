using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;

using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class AccountMapper
    {
        public BusinessRequest.FindAccountDashboardRequest Map(FindAccountDashboardRequest findAccountDashboardRequest, object companyId)
        {
            return new BusinessRequest.FindAccountDashboardRequest
            {
                Login = Formatter.RemoveMaskFromTaxId(findAccountDashboardRequest.Login),
                UserId = findAccountDashboardRequest.UserId,
                AccountId = findAccountDashboardRequest.AccountId,
                CompanyId = (long)companyId
            };
        }

        public BusinessRequest.FindAccountBalanceRequest Map(FindAccountBalanceRequest findAccountBalanceRequest)
        {
            return new BusinessRequest.FindAccountBalanceRequest
            {
                TaxId = Formatter.RemoveMaskFromTaxId(findAccountBalanceRequest.TaxId),
                AccountId = findAccountBalanceRequest.AccountId
            };
        }

        public BusinessRequest.FindBankStatementRequest Map(FindBankStatementRequest findBankStatementRequest)
        {
            return new BusinessRequest.FindBankStatementRequest
            {
                TaxId = Formatter.RemoveMaskFromTaxId(findBankStatementRequest.TaxId),
                Bank = findBankStatementRequest.Bank,
                BankBranch = findBankStatementRequest.BankBranch,
                BankAccount = findBankStatementRequest.BankAccount,
                BankAccountDigit = findBankStatementRequest.BankAccountDigit,
                AccountId = findBankStatementRequest.AccountId,
                StartDate = findBankStatementRequest.StartDate,
                EndDate = findBankStatementRequest.EndDate,
                OperationType = findBankStatementRequest.OperationType,
                Tags = findBankStatementRequest.Tags,
                TransactionType = findBankStatementRequest.TransactionType,
                UserId = findBankStatementRequest.UserId
            };
        }

        public BusinessRequest.FindAccountListByLoginRequest Map(FindAcountListByLoginRequest findAllAcountsByTaxIdRequest)
        {
            return new BusinessRequest.FindAccountListByLoginRequest
            {
                Login = Formatter.RemoveMaskFromTaxId(findAllAcountsByTaxIdRequest.Login)
            };
        }

        public BusinessRequest.FindBankStatementDetailsRequest Map(FindBankStatementDetailsRequest findBankStatementDetails)
        {
            return new BusinessRequest.FindBankStatementDetailsRequest
            {
                AccountId = findBankStatementDetails.AccountId,
                ExternalIdentifier = findBankStatementDetails.ExternalIdentifier,
                OperationType = findBankStatementDetails.OperationType,
                UserId = findBankStatementDetails.UserId,
                TaxId = findBankStatementDetails.TaxId,
                Bank = findBankStatementDetails.Bank,
                BankBranch = findBankStatementDetails.BankBranch,
                BankAccount = findBankStatementDetails.BankAccount,
                BankAccountDigit = findBankStatementDetails.BankAccountDigit
            };
        }

        public BusinessRequest.FindBankStatementMonthlySummaryRequest Map(FindBankStatementMonthlySummaryRequest findMonthlyAccountMovementsRequest)
        {
            return new BusinessRequest.FindBankStatementMonthlySummaryRequest
            {
                UserId = findMonthlyAccountMovementsRequest.UserId,
                AccountId = findMonthlyAccountMovementsRequest.AccountId,
                DateMonthly = findMonthlyAccountMovementsRequest.DateMonthly,
            };
        }

        public BusinessRequest.FindAccountListByTaxIdRequest Map(FindAccountListByTaxIdRequest findAccountDashboardRequest)
        {
            return new BusinessRequest.FindAccountListByTaxIdRequest
            {
                AccountId = findAccountDashboardRequest.AccountId,
                TaxId = Formatter.RemoveMaskFromTaxId(findAccountDashboardRequest.TaxId)
            };
        }

        public BusinessRequest.FixingChangeRequest Map(FixingChangeRequest fixingChangeRequest)
        {
            return new BusinessRequest.FixingChangeRequest
            {
                UserId = fixingChangeRequest.UserId,
                AccountId = fixingChangeRequest.AccountId,
                IsFixed = fixingChangeRequest.IsFixed
            };
        }

        public BusinessRequest.FindAccountByPhoneNumberRequest Map(FindAccountByPhoneNumberRequest findAccountByPhoneNumberRequest, object companyId)
        {
            return new BusinessRequest.FindAccountByPhoneNumberRequest
            {
                AccountId = findAccountByPhoneNumberRequest.AccountId,
                PhoneNumber = Formatter.RemoveMaskFromPhoneNumber(findAccountByPhoneNumberRequest.PhoneNumber),
                CompanyId = (long)companyId
            };
        }

        public BusinessRequest.ChangeAccountOperationLimitRequest Map(ChangeAccountOperationLimitRequest changeAccountOperationLimitRequest)
        {
            return new BusinessRequest.ChangeAccountOperationLimitRequest
            {
                UserId = changeAccountOperationLimitRequest.UserId,
                AccountId = changeAccountOperationLimitRequest.AccountId,
                TaxId = Formatter.RemoveMaskFromTaxId(changeAccountOperationLimitRequest.TaxId),
                CompanyId = changeAccountOperationLimitRequest.CompanyId,
                OperationType = changeAccountOperationLimitRequest.OperationType,
                AccountOperationLimitType = changeAccountOperationLimitRequest.AccountOperationLimitType,
                AccountOperationLimitSubType = changeAccountOperationLimitRequest.AccountOperationLimitSubType,
                MinLimitValue = changeAccountOperationLimitRequest.MinLimitValue,
                MaxLimitValue = changeAccountOperationLimitRequest.MaxLimitValue
            };
        }

        public BusinessRequest.FindAccountOperationLimitRequest Map(FindAccountOperationLimitRequest findAccountOperationLimitRequest)
        {
            return new BusinessRequest.FindAccountOperationLimitRequest
            {
                UserId = findAccountOperationLimitRequest.UserId,
                AccountId = findAccountOperationLimitRequest.AccountId,
                TaxId = Formatter.RemoveMaskFromTaxId(findAccountOperationLimitRequest.TaxId),
                Bank = findAccountOperationLimitRequest.Bank,
                BankBranch = findAccountOperationLimitRequest.BankBranch,
                BankAccount = findAccountOperationLimitRequest.BankAccount,
                BankAccountDigit = findAccountOperationLimitRequest.BankAccountDigit,
                OperationType = findAccountOperationLimitRequest.OperationType,
                AccountOperationLimitType = findAccountOperationLimitRequest.AccountOperationLimitType,
                AccountOperationLimitSubType = findAccountOperationLimitRequest.AccountOperationLimitSubType
            };
        }

        public BusinessRequest.FindAccountOperationLimitListRequest Map(FindAccountOperationLimitListRequest findAccountOperationLimitListRequest)
        {
            return new BusinessRequest.FindAccountOperationLimitListRequest
            {
                UserId = findAccountOperationLimitListRequest.UserId,
                AccountId = findAccountOperationLimitListRequest.AccountId,
                TaxId = Formatter.RemoveMaskFromTaxId(findAccountOperationLimitListRequest.TaxId),
                Bank = findAccountOperationLimitListRequest.Bank,
                BankBranch = findAccountOperationLimitListRequest.BankBranch,
                BankAccount = findAccountOperationLimitListRequest.BankAccount,
                BankAccountDigit = findAccountOperationLimitListRequest.BankAccountDigit,
                OperationType = findAccountOperationLimitListRequest.OperationType,
                AccountOperationLimitType = findAccountOperationLimitListRequest.AccountOperationLimitType,
                AccountOperationLimitSubType = findAccountOperationLimitListRequest.AccountOperationLimitSubType
            };
        }

        public BusinessRequest.FindAccountOperationRequest Map(FindAccountOperationRequest findAccountOperationRequest)
        {
            return new BusinessRequest.FindAccountOperationRequest
            {
                UserId = findAccountOperationRequest.UserId,
                AccountId = findAccountOperationRequest.AccountId,
                OperationId = findAccountOperationRequest.OperationId,
                OperationType = findAccountOperationRequest.OperationType
            };
        }
    }
}