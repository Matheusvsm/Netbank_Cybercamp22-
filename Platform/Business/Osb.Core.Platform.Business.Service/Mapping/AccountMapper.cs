using System;
using System.Globalization;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Models.Request;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using System.Linq;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class AccountMapper : Mapper
    {
        public IntegrationRequest.FindAccountBalanceRequest Map(Account account)
        {
            return new IntegrationRequest.FindAccountBalanceRequest
            {
                AccountId = account.AccountId,
                TaxId = account.TaxId,
                Bank = account.Bank,
                BankAccount = account.BankAccount,
                BankAccountDigit = account.BankAccountDigit,
                BankBranch = account.BankBranch,
                UserId = account.CreationUserId
            };
        }

        public FindAccountBalanceResult Map(IntegrationResponse.FindAccountBalanceResponse response)
        {
            return new FindAccountBalanceResult
            {
                Balance = response.Balance
            };
        }

        public FindAccountDashboardResult Map(
            Account account,
            IEnumerable<Account> accounts,
            IntegrationResponse.FindAccountBalanceResponse findAccountBalanceResponse,
            IEnumerable<UIFunction> uIFunctions
        )
        {
            return new FindAccountDashboardResult
            {
                Account = account,
                Accounts = accounts,
                Balance = findAccountBalanceResponse.Balance,
                UIFunctions = uIFunctions.Select((UIFunction) => UIFunction.Code).ToList()
            };
        }

        public FindAccountListByLoginRequest Map(FindAccountDashboardRequest request)
        {
            return new FindAccountListByLoginRequest
            {
                Login = request.Login,
                AccountId = request.AccountId,
                CompanyId = request.CompanyId
            };
        }

        public FindAccountListResult Map(IEnumerable<Account> accountList)
        {
            return new FindAccountListResult
            {
                AccountList = accountList
            };
        }

        public IntegrationRequest.FindBankStatementRequest Map(FindBankStatementRequest request, Account account)
        {
            return new IntegrationRequest.FindBankStatementRequest
            {
                AccountId = request.AccountId,
                TaxId = request.TaxId,
                Bank = account.Bank,
                BankAccount = account.BankAccount,
                BankAccountDigit = account.BankAccountDigit,
                BankBranch = account.BankBranch,
                Tags = request.Tags,
                OperationType = request.OperationType,
                EndDate = request.EndDate,
                StartDate = request.StartDate,
                TransactionType = request.TransactionType,
                UserId = request.UserId
            };
        }

        public FindBankStatementResult Map(IntegrationResponse.FindBankStatementResponse response)
        {
            List<DayTransactions> transactions = FormatTransactions(response);
            transactions.Reverse();

            return new FindBankStatementResult
            {
                Transactions = transactions
            };
        }

        public IntegrationRequest.FindBankStatementDetailsRequest Map(FindBankStatementDetailsRequest request)
        {

            Method method = request.OperationType switch
            {
                OperationType.InternalTransfer => Method.GetInternalTransferById,
                OperationType.MoneyTransfer => Method.GetMoneyTransferOutById,
                OperationType.BoletoPayment => Method.GetBoletoOutById,
                OperationType.GAREPayment => Method.GetGareOutById,
                OperationType.FGTSPayment => Method.GetFgtsOutById,
                OperationType.DARJPayment => Method.GetDarjOutById,
                OperationType.PurchaseTopUp => Method.GetTopUpById,
                OperationType.PixOut => Method.GetPixOutById,
                OperationType.PixIn => Method.GetPixInById,
                _ => throw new ArgumentOutOfRangeException(nameof(request.OperationType), $"Not expected operation value: {request.OperationType}")
            };

            return new IntegrationRequest.FindBankStatementDetailsRequest
            {
                Method = Enum.GetName(method),
                AccountId = request.AccountId,
                ExternalIdentifier = request.ExternalIdentifier,
                UserId = request.UserId,
                TaxId = request.TaxId,
                Bank = request.Bank,
                BankBranch = request.BankBranch,
                BankAccount = request.BankAccount,
                BankAccountDigit = request.BankAccountDigit
            };
        }

        public FindBankStatementDetailsResult Map(IntegrationResponse.FindMoneyTransferDetailsResponse response)
        {
            return new FindBankStatementDetailsResult
            {
                Value = response.Value,
                ToName = response.ToName,
                ToTaxId = response.ToTaxId,
                Date = response.Date,
                Description = response.Description,
                Tags = response.Tags,
                ReceiptUrl = response.ReceiptUrl

            };
        }

        public FindBankStatementDetailsResult Map(IntegrationResponse.FindInternalTransferDetailsResponse response)
        {
            return new FindBankStatementDetailsResult
            {
                Value = response.Value,
                ToName = response.ToName,
                ToTaxId = response.ToTaxId,
                Date = response.Date,
                Description = response.Description,
                Tags = response.Tags,
                ReceiptUrl = response.ReceiptUrl
            };
        }

        public FindBankStatementDetailsResult Map(IntegrationResponse.FindBoletoPaymentDetailsResponse response)
        {
            return new FindBankStatementDetailsResult
            {
                Value = response.Value,
                ToName = response.ToName,
                ToTaxId = response.ToTaxId,
                Date = response.Date,
                DueDate = response.DueDate,
                Description = response.Description,
                Tags = response.Tags,
                ReceiptUrl = response.ReceiptUrl
            };
        }

        public FindBankStatementDetailsResult Map(IntegrationResponse.FindGAREPaymentDetailsResponse response)
        {
            return new FindBankStatementDetailsResult
            {
                Value = response.TotalValue,
                ToName = response.SenderNameBank,
                ToTaxId = response.TaxIdContributor,
                Date = response.Date,
                DueDate = response.DueDate,
                Description = response.Description,
                Tags = response.Tags,
                ReceiptUrl = response.ReceiptUrl
            };
        }

        public FindBankStatementDetailsResult Map(IntegrationResponse.FindFGTSPaymentDetailsResponse response)
        {
            return new FindBankStatementDetailsResult
            {
                Value = response.TotalValue,
                ToName = response.SenderNameBank,
                ToTaxId = response.TaxIdContributor,
                Date = response.Date,
                Description = response.Description,
                Tags = response.Tags,
                ReceiptUrl = response.ReceiptUrl
            };
        }

        public FindBankStatementDetailsResult Map(IntegrationResponse.FindDARJPaymentDetailsResponse response)
        {
            return new FindBankStatementDetailsResult
            {
                Value = response.TotalValue,
                ToName = null,
                ToTaxId = null,
                Date = response.Date,
                ReceiptUrl = response.ReceiptUrl
            };
        }

        public FindBankStatementDetailsResult Map(IntegrationResponse.FindTopUpDetailsResponse response)
        {
            return new FindBankStatementDetailsResult
            {
                Value = response.Value,
                Date = response.Date,
            };
        }

        public IntegrationRequest.FindBankStatementMonthlySummaryRequest Map(DateTime? dateMonthly, Account account)
        {
            return new IntegrationRequest.FindBankStatementMonthlySummaryRequest
            {
                AccountId = account.AccountId,
                TaxId = account.TaxId,
                Bank = account.Bank,
                BankBranch = account.BankBranch,
                BankAccount = account.BankAccount,
                BankAccountDigit = account.BankAccountDigit,
                DateMonthly = dateMonthly,
                UserId = account.CreationUserId
            };
        }

        public FindBankStatementMonthlySummaryResult Map(IntegrationResponse.FindBankStatementMonthlySummaryResponse response)
        {
            return new FindBankStatementMonthlySummaryResult
            {
                MoneyInputValue = response.MoneyInputValue,
                MoneyOutputValue = response.MoneyOutputValue
            };
        }

        public FixingChangeRequest Map(FixingChangeRequest request)
        {
            return new FixingChangeRequest
            {
                AccountId = request.AccountId,
                UserId = request.UserId,
                IsFixed = request.IsFixed
            };
        }

        public FindAccountByPhoneNumberResult MapAccount(Account account)
        {
            if (account != null)
            {
                return new FindAccountByPhoneNumberResult
                {
                    Name = account.Name,
                    TaxId = account.TaxId,
                    Bank = account.Bank,
                    BankBranch = account.BankBranch,
                    BankAccount = account.BankAccount,
                    BankAccountDigit = account.BankAccountDigit,
                    AccountKey = account.AccountKey
                };
            }

            return null;
        }

        private List<DayTransactions> FormatTransactions(IntegrationResponse.FindBankStatementResponse response)
        {
            var culture = new CultureInfo("pt-BR");

            var transactions = new List<DayTransactions>();
            var transactionGroups = new Dictionary<string, DayTransactions>();
            decimal currentBalance = 0;

            foreach (var item in response.Transactions)
            {
                if (item.Subtype == 21 || item.Subtype == 22)
                    continue;

                int day = item.Date.Day;
                string month = culture.DateTimeFormat.GetAbbreviatedMonthName(item.Date.Month);
                string key = item.Date.ToShortDateString();

                if (item.Subtype == 0 || item.Subtype == 26)
                    item.Description = item.Description.Replace("Pré-", "");

                if (item.Subtype == 98 || item.Subtype == 211 || item.Subtype == 212 || item.Subtype == 203 || item.Subtype == 203)
                    item.Description = item.Description.Replace("Pré", "");

                if (item.Subtype == 70)
                    item.Description = "Cancelamento de DARJ";

                if (item.Subtype == 209 || item.Subtype == 210)
                    item.Description = "Cancelamento de Recarga";

                if (!transactionGroups.ContainsKey(key))
                {
                    transactionGroups.Add(key, new DayTransactions
                    {
                        Day = day,
                        Month = month,
                        Balance = currentBalance,
                        Transactions = new List<Models.Result.Transaction>()
                    });
                }
                transactionGroups[key].Balance = currentBalance;
                transactionGroups[key].Transactions.Add(new Models.Result.Transaction
                {
                    Title = item.Description,
                    Establishment = " ",
                    Value = item.Value,
                    ExternalIdentifier = item.ExternalIdentifier,
                    OperationType = item.OperationType,
                    Date = item.Date,
                });

            }

            foreach (var dictionaryItem in transactionGroups)
                transactions.Add(dictionaryItem.Value);

            foreach (var dayGroup in transactions)
                dayGroup.Transactions.Reverse();

            return transactions;
        }

        public IntegrationRequest.ChangeAccountOperationLimitRequest Map(ChangeAccountOperationLimitRequest request)
        {
            return new IntegrationRequest.ChangeAccountOperationLimitRequest
            {
                AccountId = request.AccountId,
                CompanyId = request.CompanyId,
                TaxId = request.TaxId,
                Bank = request.Bank,
                BankBranch = request.BankBranch,
                BankAccount = request.BankAccount,
                BankAccountDigit = request.BankAccountDigit,
                OperationType = request.OperationType,
                AccountOperationLimitType = request.AccountOperationLimitType,
                AccountOperationLimitSubType = request.AccountOperationLimitSubType,
                MinLimitValue = request.MinLimitValue,
                MaxLimitValue = request.MaxLimitValue
            };
        }

        public IntegrationRequest.FindAccountOperationLimitRequest Map(FindAccountOperationLimitRequest request)
        {
            return new IntegrationRequest.FindAccountOperationLimitRequest
            {
                AccountId = request.AccountId,
                TaxId = request.TaxId,
                Bank = request.Bank,
                BankBranch = request.BankBranch,
                BankAccount = request.BankAccount,
                BankAccountDigit = request.BankAccountDigit,
                OperationType = request.OperationType,
                AccountOperationLimitType = request.AccountOperationLimitType,
                AccountOperationLimitSubType = request.AccountOperationLimitSubType
            };
        }

        public IntegrationRequest.FindAccountOperationLimitListRequest Map(FindAccountOperationLimitListRequest request)
        {
            return new IntegrationRequest.FindAccountOperationLimitListRequest
            {
                AccountId = request.AccountId,
                TaxId = request.TaxId,
                Bank = request.Bank,
                BankBranch = request.BankBranch,
                BankAccount = request.BankAccount,
                BankAccountDigit = request.BankAccountDigit,
                OperationType = request.OperationType,
                AccountOperationLimitType = request.AccountOperationLimitType,
                AccountOperationLimitSubType = request.AccountOperationLimitSubType
            };
        }

        public FindBankStatementDetailsResult Map(IntegrationResponse.FindPixDetailsResponse response)
        {

            bool dateIsValid = DateTime.TryParse(response.Date, out var parseDate);

            return new FindBankStatementDetailsResult
            {
                ToName = response.ToName,
                ToTaxId = response.ToTaxId,
                FromBank = response.Bank,
                FromBankBranch = response.BankBranch,
                FromBankAccount = response.BankAccount,
                FromBankAccountDigit = response.BankAccountDigit,
                ToBank = response.ToBankCode,
                ToBankBranch = response.ToBankBranch,
                ToBankAccount = response.ToBankAccount,
                ToBankAccountDigit = response.ToBankAccountDigit,
                Value = response.Value,
                Date = dateIsValid ? parseDate : null,
                ReceiptUrl = response.ReceiptUrl
            };
        }
        public FindAccountOperationResult Map(Operation operation)
        {
            return new FindAccountOperationResult
            {
                ExternalIdentifier = operation.ExternalIdentifier
            };
        }
    }
}