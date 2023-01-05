using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class TaxPaymentMapper
    {
        public BusinessRequest.FGTSPaymentRequest Map(FGTSPaymentRequest fgtsPaymentRequest)
        {
            return new BusinessRequest.FGTSPaymentRequest
            {
                UserId = fgtsPaymentRequest.UserId,
                AccountId = fgtsPaymentRequest.AccountId,
                TaxId = Formatter.RemoveMaskFromTaxId(fgtsPaymentRequest.TaxId),
                ContributorTaxId = Formatter.RemoveMaskFromTaxId(fgtsPaymentRequest.ContributorTaxId),
                PrincipalValue = fgtsPaymentRequest.PrincipalValue,
                CodeRevenue = fgtsPaymentRequest.CodeRevenue,
                Barcode = Formatter.MaskFromBarcode(fgtsPaymentRequest.Barcode),
                FgtsIdentifier = fgtsPaymentRequest.FgtsIdentifier,
                SocialConnectivityCode = fgtsPaymentRequest.SocialConnectivityCode,
                SocialConnectivityDigit = fgtsPaymentRequest.SocialConnectivityDigit,
                PaymentDate = fgtsPaymentRequest.PaymentDate,
                Tags = fgtsPaymentRequest.Tags,
                RateValueType = fgtsPaymentRequest.RateValueType,
                Description = fgtsPaymentRequest.Description
            };
        }

        public BusinessRequest.DARJPaymentRequest Map(DARJPaymentRequest darjPaymentRequest)
        {
            return new BusinessRequest.DARJPaymentRequest
            {
                UserId = darjPaymentRequest.UserId,
                AccountId = darjPaymentRequest.AccountId,
                TaxId = Formatter.RemoveMaskFromTaxId(darjPaymentRequest.TaxId),
                PaymentDate = darjPaymentRequest.PaymentDate,
                RateValueType = darjPaymentRequest.RateValueType,
                Description = darjPaymentRequest.Description,
                ContributorTaxId = Formatter.RemoveMaskFromTaxId(darjPaymentRequest.ContributorTaxId),
                ReferenceNumber = darjPaymentRequest.ReferenceNumber,
                PrincipalValue = darjPaymentRequest.PrincipalValue,
                FineValue = darjPaymentRequest.FineValue,
                InterestValue = darjPaymentRequest.InterestValue,
                MonetaryValue = darjPaymentRequest.MonetaryValue,
                TotalValue = darjPaymentRequest.TotalValue,
                RateValue = darjPaymentRequest.RateValue,
                DueDate = Formatter.AbsoluteEnd(darjPaymentRequest.DueDate),
                CodeRevenue = darjPaymentRequest.CodeRevenue,
                StateRegistration = darjPaymentRequest.StateRegistration,
                OriginDocument = darjPaymentRequest.OriginDocument,
                Tags = darjPaymentRequest.Tags
            };
        }


        public BusinessRequest.GAREPaymentRequest Map(GAREPaymentRequest garePaymentRequest)
        {
            return new BusinessRequest.GAREPaymentRequest
            {
                AccountId = garePaymentRequest.AccountId,
                UserId = garePaymentRequest.UserId,
                TaxId = Formatter.RemoveMaskFromTaxId(garePaymentRequest.TaxId),
                ContributorTaxId = Formatter.RemoveMaskFromTaxId(garePaymentRequest.ContributorTaxId),
                ReferenceNumber = garePaymentRequest.ReferenceNumber,
                PrincipalValue = garePaymentRequest.PrincipalValue,
                FineValue = garePaymentRequest.FineValue,
                InterestValue = garePaymentRequest.InterestValue,
                TotalValue = garePaymentRequest.TotalValue,
                RateValue = garePaymentRequest.RateValue,
                DueDate = Formatter.AbsoluteEnd(garePaymentRequest.DueDate),
                PaymentDate = garePaymentRequest.PaymentDate,
                Tags = garePaymentRequest.Tags,
                CodeRevenue = garePaymentRequest.CodeRevenue,
                StateRegistration = garePaymentRequest.StateRegistration,
                ActiveDebit = garePaymentRequest.ActiveDebit,
                QuoteNumberNotification = garePaymentRequest.QuoteNumberNotification,
                RateValueType = garePaymentRequest.RateValueType,
                Description = garePaymentRequest.Description,
                GAREType = garePaymentRequest.GAREType
            };
        }
    }
}