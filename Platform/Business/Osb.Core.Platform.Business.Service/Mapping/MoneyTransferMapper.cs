using Osb.Core.Platform.Business.Service.Models.Result;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Business.Entity.Models;
using System.Collections.Generic;
using System.Linq;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class MoneyTransferMapper : Mapper
    {
        public IntegrationRequest.FindExpectedTransferDateRequest Map(Models.Request.FindExpectedTransferDateRequest request)
        {
            return new IntegrationRequest.FindExpectedTransferDateRequest
            {
                AccountId = request.AccountId,
                ActualDateTransfer = request.ActualDateTransfer,
                BankCode = request.BankCode,
                AccountType = request.AccountType,
                CustomFormatDate = request.CustomFormatDate,
                UserId = request.UserId
            };
        }

        public FindExpectedTransferDateResult Map(FindExpectedTransferDateResponse response)
        {
            return new FindExpectedTransferDateResult
            {
                ExpectedTransferDate = response.ExpectedTransferDate
            };
        }

        public IntegrationRequest.MoneyTransferRequest Map(MoneyTransfer moneyTransfer, Account account, BankingData bankingData, IEnumerable<OperationTag> operationTags)
        {
            return new IntegrationRequest.MoneyTransferRequest()
            {
                AccountId = moneyTransfer.FromAccountId,
                Identifier = moneyTransfer.Identifier,
                FromTaxId = account.TaxId,
                ToTaxId = moneyTransfer.ToTaxId,
                ToName = moneyTransfer.ToName,
                Bank = bankingData.Bank,
                BankBranch = bankingData.BankBranch,
                BankAccount = bankingData.BankAccount,
                BankAccountDigit = bankingData.BankAccountDigit,
                Value = moneyTransfer.TransferValue,
                TransferDate = moneyTransfer.TransferDate,
                Description = moneyTransfer.Description,
                Tags = operationTags.Select((OperationTag) => OperationTag.Tag).ToList(),
                UserId = moneyTransfer.CreationUserId
            };
        }
    }
}
