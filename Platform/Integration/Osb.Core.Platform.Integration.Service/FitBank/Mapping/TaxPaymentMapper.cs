using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class TaxPaymentMapper : Mapper
    {
        public ExternalRequest Map(FGTSPaymentRequest fgtsPaymentRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
               AuthorizationMapper.Map(companyAuthentication),
               fgtsPaymentRequest.Headers
           );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = fgtsPaymentRequest.Method,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    FGTSPaymentId = fgtsPaymentRequest.FGTSPaymentId,
                    AccountId = fgtsPaymentRequest.AccountId,
                    TaxNumber = fgtsPaymentRequest.TaxId,
                    ContributorTaxNumber = fgtsPaymentRequest.ContributorTaxId,
                    PrincipalValue = fgtsPaymentRequest.PrincipalValue,
                    FromBank = fgtsPaymentRequest.FromBank,
                    FromBankBranch = fgtsPaymentRequest.FromBankBranch,
                    FromBankAccount = fgtsPaymentRequest.FromBankAccount,
                    FromBankAccountDigit = fgtsPaymentRequest.FromBankAccountDigit,
                    CodeRevenue = fgtsPaymentRequest.CodeRevenue,
                    Barcode = fgtsPaymentRequest.Barcode,
                    FgtsIdentifier = fgtsPaymentRequest.FgtsIdentifier,
                    SocialConnectivityCode = fgtsPaymentRequest.SocialConnectivityCode,
                    SocialConnectivityDigit = fgtsPaymentRequest.SocialConnectivityDigit,
                    PaymentDate = fgtsPaymentRequest.PaymentDate,
                    Tags = fgtsPaymentRequest.Tags,
                    RateValueType = fgtsPaymentRequest.RateValueType,
                    Description = fgtsPaymentRequest.Description,
                    Identifier = fgtsPaymentRequest.Identifier,
                }
            };
        }

        public ExternalRequest Map(DARJPaymentRequest darjPaymentRequest, CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
               AuthorizationMapper.Map(companyAuthentication),
               darjPaymentRequest.Headers
           );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = darjPaymentRequest.Method,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    TaxNumber = darjPaymentRequest.TaxId,
                    ContributorTaxNumber = darjPaymentRequest.ContributorTaxId,
                    ReferenceNumber = darjPaymentRequest.ReferenceNumber,
                    PrincipalValue = darjPaymentRequest.PrincipalValue,
                    FineValue = darjPaymentRequest.FineValue,
                    InterestValue = darjPaymentRequest.InterestValue,
                    MonetaryValue = darjPaymentRequest.MonetaryValue,
                    TotalValue = darjPaymentRequest.TotalValue,
                    RateValue = darjPaymentRequest.RateValue,
                    DueDate = darjPaymentRequest.DueDate,
                    PaymentDate = darjPaymentRequest.PaymentDate,
                    Tags = darjPaymentRequest.Tags,
                    CodeRevenue = darjPaymentRequest.CodeRevenue,
                    StateRegistration = darjPaymentRequest.StateRegistration,
                    OriginDocument = darjPaymentRequest.OriginDocument,
                    RateValueType = darjPaymentRequest.RateValueType,
                    Description = darjPaymentRequest.Description,
                    Identifier = darjPaymentRequest.Identifier,
                    FromBank = darjPaymentRequest.FromBank,
                    FromBankBranch = darjPaymentRequest.FromBankBranch,
                    FromBankAccount = darjPaymentRequest.FromBankAccount,
                    FromBankAccountDigit = darjPaymentRequest.FromBankAccountDigit
                }
            };
        }

        public ExternalRequest Map(
            GAREPaymentRequest garePaymentRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                garePaymentRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = garePaymentRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = garePaymentRequest.TaxId,
                    ContributorTaxNumber = garePaymentRequest.ContributorTaxId,
                    ReferenceNumber = garePaymentRequest.ReferenceNumber,
                    PrincipalValue = garePaymentRequest.PrincipalValue,
                    FineValue = garePaymentRequest.FineValue,
                    InterestValue = garePaymentRequest.InterestValue,
                    TotalValue = garePaymentRequest.TotalValue,
                    RateValue = garePaymentRequest.RateValueType,
                    DueDate = garePaymentRequest.DueDate,
                    PaymentDate = garePaymentRequest.PaymentDate,
                    Tags = garePaymentRequest.Tags,
                    CodeRevenue = garePaymentRequest.CodeRevenue,
                    StateRegistration = garePaymentRequest.StateRegistration,
                    ActiveDebit = garePaymentRequest.ActiveDebit,
                    QuoteNumberNotification = garePaymentRequest.QuoteNumberNotification,
                    RateValueType = garePaymentRequest.RateValueType,
                    Description = garePaymentRequest.Description,
                    Identifier = garePaymentRequest.Identifier,
                    GAREType = garePaymentRequest.GAREType,
                    FromBank = garePaymentRequest.FromBank,
                    FromBankBranch = garePaymentRequest.FromBankBranch,
                    FromBankAccount = garePaymentRequest.FromBankAccount,
                    FromBankAccountDigit = garePaymentRequest.FromBankAccountDigit,
                }
            };
        }
    }
}