using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Service.Models.Result;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class BoletoPaymentMapper : Mapper
    {
        public IntegrationRequest.FindInfosPaymentCIPByBarcodeRequest MapCIP(Models.Request.FindBoletoInfoRequest findBoletoInfoRequest)
        {
            return new IntegrationRequest.FindInfosPaymentCIPByBarcodeRequest
            {
                AccountId = findBoletoInfoRequest.AccountId,
                TaxId = findBoletoInfoRequest.TaxId,
                BarCode = findBoletoInfoRequest.NumericSequence,
                UserId = findBoletoInfoRequest.UserId
            };
        }

        public IntegrationRequest.FindInfosPaymentByBarcodeRequest MapBoletoInfo(Models.Request.FindBoletoInfoRequest findBoletoInfoRequest)
        {
            return new IntegrationRequest.FindInfosPaymentByBarcodeRequest
            {
                AccountId = findBoletoInfoRequest.AccountId,
                Barcode = findBoletoInfoRequest.NumericSequence,
                UserId = findBoletoInfoRequest.UserId
            };
        }

        public IntegrationRequest.BoletoPaymentRequest Map(BoletoPayment boletoPayment, Account account)
        {
            return new IntegrationRequest.BoletoPaymentRequest
            {
                AccountId = boletoPayment.AccountId,
                Name = boletoPayment.Name,
                TaxId = boletoPayment.TaxId,
                Bank = account.Bank,
                BankBranch = account.BankBranch,
                BankAccount = account.BankAccount,
                BankAccountDigit = account.BankAccountDigit,
                ReceiverName = boletoPayment.ReceiverName,
                ReceiverTaxId = boletoPayment.ReceiverTaxId,
                PayerName = boletoPayment.PayerName,
                PayerTaxId = boletoPayment.PayerTaxId,
                Barcode = boletoPayment.Barcode,
                PaymentValue = boletoPayment.PaymentValue,
                PaymentDate = boletoPayment.PaymentDate,
                DueDate = boletoPayment.DueDate,
                DiscountValue = boletoPayment.DiscountValue,
                Description = boletoPayment.Description,
                Identifier = boletoPayment.Identifier,
                UserId = boletoPayment.CreationUserId
            };
        }

        public FindBoletoInfoResult Map(IntegrationResponse.FindInfosPaymentCIPByBarcodeResponse response)
        {
            return new FindBoletoInfoResult
            {
                ReceiverTaxId = response.ReceiverTaxId,
                ReceiverName = response.ReceiverName,
                PayerTaxId = response.PayerTaxId,
                PayerName = response.PayerName,
                PaymentValue = response.PaymentValue,
                PaymentDate = response.PaymentDate,
                DueDate = response.DueDate,
                DiscountValue = response.DiscountValue,
                FineValue = response.FineValue,
                Barcode = response.Barcode
            };
        }

        public FindBoletoInfoResult Map(IntegrationResponse.FindInfosPaymentByBarcodeReponse response)
        {
            return new FindBoletoInfoResult
            {
                DigitableLine = response.DigitableLine,
                Barcode = response.Barcode,
                BankCode = response.BankCode,
                BankName = response.BankName,
                PaymentValue = response.Value,
                PaymentDate = response.PaymentDate,
                DueDate = response.DueDate != null ? response.DueDate : response.PaymentDate,
                ConcessionaireName = response.ConcessionaireName,
                ConcessionaireCode = response.ConcessionaireCode
            };
        }

        public IntegrationRequest.VerifyBoletoCanBePaidRequest MapVerifyCanBePaid(BusinessRequest.FindBoletoInfoRequest findBoletoInfoRequest)
        {
            return new IntegrationRequest.VerifyBoletoCanBePaidRequest
            {
                AccountId = findBoletoInfoRequest.AccountId,
                Barcode = findBoletoInfoRequest.NumericSequence,
                UserId = findBoletoInfoRequest.UserId
            };
        }

        public VerifyBoletoCanBePaidResult Map(IntegrationResponse.VerifyBoletoCanBePaidResponse verifiyBoletoCanBePaidResponse)
        {
            return new VerifyBoletoCanBePaidResult
            {
                CanBePaid = verifiyBoletoCanBePaidResponse.CanBePaid
            };
        }

        public IntegrationRequest.FindExpectedBoletoPaymentDateRequest Map(BusinessRequest.FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest)
        {
            return new IntegrationRequest.FindExpectedBoletoPaymentDateRequest
            {
                AccountId = findExpectedBoletoPaymentDateRequest.AccountId,
                ActualDatePayment = findExpectedBoletoPaymentDateRequest.ActualDatePayment.Value,
                BarCode = findExpectedBoletoPaymentDateRequest.BarCode,
                UserId = findExpectedBoletoPaymentDateRequest.UserId
            };
        }

        public FindExpectedBoletoPaymentDateResult Map(IntegrationResponse.FindExpectedBoletoPaymentDateResponse findExpectedBoletoPaymentDateResponse)
        {
            return new FindExpectedBoletoPaymentDateResult
            {
                ExpectedBoletoPaymentDate = findExpectedBoletoPaymentDateResponse.ExpectedBoletoPaymentDate
            };
        }

        public FindScanLicenseKeyResult Map(ScanLicenseKey scanLicenseKey)
        {
            return new FindScanLicenseKeyResult
            {
                LicenseKey = scanLicenseKey.LicenseKey
            };
        }
    }
}