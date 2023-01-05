using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;


namespace Osb.Core.Platform.Business.Service.Interfaces
{
    public interface IAccountService
    {
        void Save(AccountWebhookRequest accountWebhookRequest);
        FindAccountDashboardResult FindAccountDashboard(FindAccountDashboardRequest findAccountDashboardRequest);
        FindAccountBalanceResult FindAccountBalance(FindAccountBalanceRequest findAccountBalanceRequest);
        FindBankStatementResult FindBankStatement(FindBankStatementRequest findBankStatementRequest);
        FindBankStatementDetailsResult FindBankStatementDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindBankStatementMonthlySummaryResult FindBankStatementMonthlySummary(FindBankStatementMonthlySummaryRequest findBankStatementMonthlySummaryRequest);
        FindAccountListResult FindAccountListByUserId(long userId);
        FindAccountListResult FindAccountListByUserIdAndCompanyId(long userId, long companyId);
        FindAccountListResult FindAccountListByLogin(FindAccountListByLoginRequest findAccountListByLoginRequest);
        FindAccountListResult FindAccountListByTaxId(FindAccountListByTaxIdRequest findAccountByTaxIdRequest);
        void FixingChange(FixingChangeRequest fixingChangeRequest);
        FindAccountByPhoneNumberResult FindAccountByPhoneNumber(FindAccountByPhoneNumberRequest findAccountByPhoneNumberRequest);
        Account FindAccountByAccountKey(string accountKey);
        ChangeAccountOperationLimitResult ChangeAccountOperationLimit(ChangeAccountOperationLimitRequest changeAccountOperationLimitRequest);
        FindAccountOperationLimitResult FindAccountOperationLimit(FindAccountOperationLimitRequest findAccountOperationLimitRequest);
        FindAccountOperationLimitListResult FindAccountOperationLimitList(FindAccountOperationLimitListRequest findAccountOperationLimitListRequest);
        FindAccountOperationResult FindAccountOperation(FindAccountOperationRequest findAccountOperationRequest);
    }
}