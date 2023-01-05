using System;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources.MoneyTransferExcMsg;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class MoneyTransferValidator
    {
        public void Validate(FindExpectedTransferDateRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0001);

            if (request.ActualDateTransfer < DateTime.MinValue.AddDays(1))
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0002);

            if (string.IsNullOrEmpty(request.BankCode))
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0003);

            if (string.IsNullOrEmpty(request.AccountType))
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0004);
        }

        // public void Validate(FindMoneyTransferRequest request)
        // {
        //     if (request.FromTaxNumber == "")
        //         throw new OsbBusinessException();

        //     if (request.ToName == "")
        //         throw new OsbBusinessException();

        //     if (request.Bank == "")
        //         throw new OsbBusinessException();

        //     if (request.AccountType == 0)
        //         throw new OsbBusinessException();

        //     if (request.BankBranch == "")
        //         throw new OsbBusinessException();

        //     if (request.BankAccountDigit == "")
        //         throw new OsbBusinessException();

        //     if (request.Value == 0)
        //         throw new OsbBusinessException();

        //     if (request.PaymentDate < DateTime.Now)
        //         throw new OsbBusinessException();

        //     if (request.Description == "")
        //         throw new OsbBusinessException();
        // }

        public void Validate(MoneyTransferRequest request)
        {
            // if (request.AccountId == 0)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0004);

            // if (request.TaxId == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0001);

            // if (request.ToName == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0002);

            // if (request.Bank == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0003);

            // if (request.AccountType == null)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0005);

            // if (request.BankBranch == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0006);

            // if (request.BankAccountDigit == string.Empty)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0007);

            // if (request.Value <= 0)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0008);

            // if (request.PaymentDate < DateTime.Now)
            //     throw new OsbBusinessException(MoneyTransferMsg.MT0009);
        }

        public void Validate(UpdateMoneyTransferRequest updateMoneyTransferRequest)
        {
            if (!Enum.IsDefined<MoneyTransferStatus>(updateMoneyTransferRequest.Status))
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0005);

            if (updateMoneyTransferRequest.MoneyTransferId <= 0)
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0006);

            if (updateMoneyTransferRequest.ExternalIdentifier <= 0)
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0006);
        }

        public void Validate(CancelMoneyTransferRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0001);

            if (request.UserId == 0)
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0007);

            if (request.ExternalIdentifier <= 0)
                throw new OsbBusinessException(MoneyTransferExcMsg.EXC0008);
        }

        public void Validate(NotificationMoneyTransferInRequest notificationMoneyTransferInRequest)
        {
            if(String.IsNullOrEmpty(notificationMoneyTransferInRequest.Bank))
            throw new OsbBusinessException(MoneyTransferExcMsg.EXC0009);
            
            if(String.IsNullOrEmpty(notificationMoneyTransferInRequest.BankBranch))
            throw new OsbBusinessException(MoneyTransferExcMsg.EXC0010);

             if(String.IsNullOrEmpty(notificationMoneyTransferInRequest.BankAccountDigit))
            throw new OsbBusinessException(MoneyTransferExcMsg.EXC0012);

            if(String.IsNullOrEmpty(notificationMoneyTransferInRequest.BankAccount))
            throw new OsbBusinessException(MoneyTransferExcMsg.EXC0011);

            if(notificationMoneyTransferInRequest.TransferValue <= 0)
            throw new OsbBusinessException(MoneyTransferExcMsg.EXC0013);
        }
    }
}


