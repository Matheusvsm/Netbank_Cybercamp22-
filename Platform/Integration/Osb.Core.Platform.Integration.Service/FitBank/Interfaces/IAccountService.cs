using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.FitBank.Interfaces
{
    public interface IAccountService
    {
        FindAccountBalanceResponse FindAccountBalance(FindAccountBalanceRequest getBalanceRequest);
        FindBankStatementResponse FindBankStatement(FindBankStatementRequest findBankStatementRequest);
        FindMoneyTransferDetailsResponse FindMoneyTransferDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindInternalTransferDetailsResponse FindInternalTransferDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindBoletoPaymentDetailsResponse FindBoletoPaymentDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindFGTSPaymentDetailsResponse FindFGTSPaymentDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindGAREPaymentDetailsResponse FindGAREPaymentDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindDARJPaymentDetailsResponse FindDARJPaymentDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindTopUpDetailsResponse FindTopUpDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
        FindBankStatementMonthlySummaryResponse FindBankStatementMonthlySummary(FindBankStatementMonthlySummaryRequest findBankStatementMonthlySummaryRequest);
        ChangeAccountOperationLimitResponse ChangeAccountOperationLimit(ChangeAccountOperationLimitRequest changeAccountOperationLimitRequest);
        FindAccountOperationLimitResponse FindAccountOperationLimit(FindAccountOperationLimitRequest findAccountOperationLimitRequest);
        FindAccountOperationLimitListResponse FindAccountOperationLimitList(FindAccountOperationLimitListRequest findAccountOperationLimitListRequest);
        FindPixDetailsResponse FindPixTransferDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest);
    }
}