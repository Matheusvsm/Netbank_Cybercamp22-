using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Mapping;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using System;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class BoletoPaymentMapper : Mapper
    {
        public ExternalRequest Map(
           BoletoPaymentRequest boletoPaymentRequest,
           CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                boletoPaymentRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = boletoPaymentRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    Name = boletoPaymentRequest.Name,
                    TaxNumber = boletoPaymentRequest.TaxId,
                    Bank = boletoPaymentRequest.Bank,
                    BankBranch = boletoPaymentRequest.BankBranch,
                    BankAccount = boletoPaymentRequest.BankAccount,
                    BankAccountDigit = boletoPaymentRequest.BankAccountDigit,
                    BeneficiaryName = boletoPaymentRequest.ReceiverName,
                    BeneficiaryTaxNumber = boletoPaymentRequest.ReceiverTaxId,
                    PayerName = boletoPaymentRequest.PayerName,
                    PayerTaxNumber = boletoPaymentRequest.PayerTaxId,
                    Barcode = boletoPaymentRequest.Barcode,
                    PrincipalValue = boletoPaymentRequest.PaymentValue,
                    PaymentDate = boletoPaymentRequest.PaymentDate,
                    DueDate = boletoPaymentRequest.DueDate,
                    DiscountValue = boletoPaymentRequest.DiscountValue,
                    Description = boletoPaymentRequest.Description,
                    Identifier = boletoPaymentRequest.Identifier,
                    RateValueType = 1
                }
            };
        }

        public ExternalRequest Map(
            FindInfosPaymentCIPByBarcodeRequest findInfosPaymentCIPByBarcodeRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findInfosPaymentCIPByBarcodeRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findInfosPaymentCIPByBarcodeRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = findInfosPaymentCIPByBarcodeRequest.TaxId,
                    BarCode = findInfosPaymentCIPByBarcodeRequest.BarCode
                }
            };
        }

        public ExternalRequest Map(
            FindExpectedBoletoPaymentDateRequest findExpectedBoletoPaymentDateRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findExpectedBoletoPaymentDateRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findExpectedBoletoPaymentDateRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    ActualDatePayment = findExpectedBoletoPaymentDateRequest.ActualDatePayment,
                    BarCode = findExpectedBoletoPaymentDateRequest.BarCode
                }
            };
        }

        public FindExpectedBoletoPaymentDateResponse Map(ExternalFindExpectedBoletoPaymentDateResponse externalFindExpectedBoletoPaymentDateResponse)
        {
            return new FindExpectedBoletoPaymentDateResponse
            {
                ExpectedBoletoPaymentDate = Convert.ToDateTime(externalFindExpectedBoletoPaymentDateResponse.ExpectedBoletoPaymentDate)
            };
        }

        public ExternalRequest Map(
            FindInfosPaymentByBarcodeRequest findInfosPaymentByBarcodeRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findInfosPaymentByBarcodeRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findInfosPaymentByBarcodeRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    BarCode = findInfosPaymentByBarcodeRequest.Barcode
                }
            };
        }

        public ExternalRequest Map(
           VerifyBoletoCanBePaidRequest verifyBoletoCanBePaidRequest,
           CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                verifyBoletoCanBePaidRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = verifyBoletoCanBePaidRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    Barcode = verifyBoletoCanBePaidRequest.Barcode
                }
            };
        }
    }
}