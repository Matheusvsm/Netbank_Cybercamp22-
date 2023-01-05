using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Platform.Common.Entity.Enums;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class BoletoPaymentMapper
    {
        public BusinessRequest.BoletoPaymentRequest Map(BoletoPaymentRequest boletoPaymentRequest)
        {
            return new BusinessRequest.BoletoPaymentRequest
            {
                UserId = boletoPaymentRequest.UserId,
                AccountId = boletoPaymentRequest.AccountId,
                Name = boletoPaymentRequest.Name,
                TaxId = boletoPaymentRequest.TaxId,
                Bank = boletoPaymentRequest.Bank,
                BankBranch = boletoPaymentRequest.BankBranch,
                BankAccount = boletoPaymentRequest.BankAccount,
                BankAccountDigit = boletoPaymentRequest.BankAccountDigit,
                ReceiverName = boletoPaymentRequest.ReceiverName,
                ReceiverTaxId = boletoPaymentRequest.ReceiverTaxId,
                PayerName = boletoPaymentRequest.ReceiverName,
                PayerTaxId = boletoPaymentRequest.PayerTaxId,
                Barcode = boletoPaymentRequest.Barcode,
                PaymentValue = boletoPaymentRequest.PaymentValue,
                PaymentDate = boletoPaymentRequest.PaymentDate,
                DueDate = boletoPaymentRequest.DueDate,
                DiscountValue = boletoPaymentRequest.DiscountValue,
                Description = boletoPaymentRequest.Description,
                Tags = boletoPaymentRequest.Tags,
                Attachments = boletoPaymentRequest.Attachments
            };
        }

        public BusinessRequest.FindBoletoInfoRequest Map(FindBoletoInfoRequest findBoletoInfoRequest)
        {
            return new BusinessRequest.FindBoletoInfoRequest
            {
                UserId = findBoletoInfoRequest.UserId,
                AccountId = findBoletoInfoRequest.AccountId,
                TaxId = findBoletoInfoRequest.TaxId,
                NumericSequence = findBoletoInfoRequest.NumericSequence,
                BoletoType = findBoletoInfoRequest.NumericSequence.Substring(0, 1) == "8" ? BoletoType.Concessionare : BoletoType.Bank
            };
        }

        public BusinessRequest.FindExpectedBoletoPaymentDateRequest Map(FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            return new BusinessRequest.FindExpectedBoletoPaymentDateRequest
            {
                AccountId = findExpectedBoletoPaymentDateRequest.AccountId,
                ActualDatePayment = findExpectedBoletoPaymentDateRequest.ActualPaymentDate.Value,
                BarCode = findExpectedBoletoPaymentDateRequest.Barcode,
                UserId = findExpectedBoletoPaymentDateRequest.UserId
            };
        }

        public BusinessRequest.FindScanLicenseKeyRequest Map(object companyId)
        {
            return new BusinessRequest.FindScanLicenseKeyRequest
            {
                CompanyId = (long)companyId
            };
        }
    }
}