using System;
using Osb.Core.Platform.Common.Entity.Enums;
using Osb.Core.Webhook.Api.Models.Request;
using BusinessService = Osb.Core.Platform.Business.Service.Models.Request;
namespace Osb.Core.Webhook.Api.Mapping
{
    public class MoneyTransferMapper
    {
        public BusinessService.UpdateMoneyTransferRequest Map(UpdateMoneyTransferRequest updateMoneyTransferStatusRequest)
        {
            return new BusinessService.UpdateMoneyTransferRequest
            {
                ExternalIdentifier = updateMoneyTransferStatusRequest.ExternalIdentifier,
                Status = Enum.Parse<MoneyTransferStatus>(updateMoneyTransferStatusRequest.Status)
            };
        }

       public BusinessService.NotificationMoneyTransferInRequest Map (NotificationMoneyTransferInRequest notificationMoneyTransferInRequest)
       {
            return new BusinessService.NotificationMoneyTransferInRequest
            {
                TaxId = notificationMoneyTransferInRequest.TaxNumber,
                Bank = notificationMoneyTransferInRequest.BankCode,
                BankBranch = notificationMoneyTransferInRequest.BankBranch,
                BankAccount = notificationMoneyTransferInRequest.BankAccount,
                BankAccountDigit = notificationMoneyTransferInRequest.BankAccountDigit,
                TransferValue = notificationMoneyTransferInRequest.TotalValue,
                Status = Enum.Parse<MoneyTransferStatus>(notificationMoneyTransferInRequest.Status) 
            };

       }    
    }
}