using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class MoneyTransferMapper
    {
        public BusinessRequest.FindExpectedTransferDateRequest Map(FindExpectedTransferDateRequest findExpectedTransferDateRequest)
        {
            return new BusinessRequest.FindExpectedTransferDateRequest
            {
                AccountId = findExpectedTransferDateRequest.AccountId,
                ActualDateTransfer = findExpectedTransferDateRequest.ActualTransferDate,
                BankCode = findExpectedTransferDateRequest.BankCode,
                AccountType = findExpectedTransferDateRequest.AccountType,
                CustomFormatDate = findExpectedTransferDateRequest.CustomFormatDate,
                UserId = findExpectedTransferDateRequest.UserId
            };
        }

        public BusinessRequest.MoneyTransferRequest Map(MoneyTransferRequest insertMoneyTransferRequest)
        {
            return new BusinessRequest.MoneyTransferRequest
            {
                AccountId = insertMoneyTransferRequest.AccountId,
                UserId = insertMoneyTransferRequest.UserId,
                ToTaxId = Formatter.RemoveMaskFromTaxId(insertMoneyTransferRequest.ToTaxId),
                ToName = insertMoneyTransferRequest.ToName,
                Bank = insertMoneyTransferRequest.ToBank,
                BankBranch = insertMoneyTransferRequest.ToBankBranch,
                BankAccount = insertMoneyTransferRequest.ToBankAccount,
                BankAccountDigit = insertMoneyTransferRequest.ToBankAccountDigit,
                Value = insertMoneyTransferRequest.TransferValue,
                TransferDate = insertMoneyTransferRequest.TransferDate,
                Description = insertMoneyTransferRequest.Description,
                Attachments = insertMoneyTransferRequest.Attachments,
                Tags = insertMoneyTransferRequest.Tags
            };
        }

        public BusinessRequest.UpdateMoneyTransferRequest Map(UpdateMoneyTransferRequest updateMoneyTransferRequest)
        {
            return new BusinessRequest.UpdateMoneyTransferRequest
            {
                MoneyTransferId = updateMoneyTransferRequest.MoneyTransferId,
                Status = updateMoneyTransferRequest.Status,
                UserId = updateMoneyTransferRequest.UserId,
                AccountId = updateMoneyTransferRequest.AccountId
            };
        }
    }
}