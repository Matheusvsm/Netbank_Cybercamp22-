using System.Linq;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class TaxPaymentMapper : Mapper
    {
        public IntegrationRequest.FGTSPaymentRequest Map(FGTSPayment fgtsPayment, Account account, IEnumerable<OperationTag> operationTags)
        {

            return new IntegrationRequest.FGTSPaymentRequest
            {
                FGTSPaymentId = fgtsPayment.FGTSPaymentId,
                AccountId = fgtsPayment.AccountId,
                TaxId = fgtsPayment.TaxId,
                ContributorTaxId = fgtsPayment.ContributorTaxId,
                PrincipalValue = fgtsPayment.PrincipalValue,
                CodeRevenue = fgtsPayment.CodeRevenue,
                Barcode = fgtsPayment.Barcode, 
                FgtsIdentifier = fgtsPayment.FGTSIdentifier,
                SocialConnectivityCode = fgtsPayment.SocialConnectivityCode, 
                SocialConnectivityDigit = fgtsPayment.SocialConnectivityDigit,
                Tags = operationTags.Select((OperationTag) => OperationTag.Tag).ToList(), 
                PaymentDate = fgtsPayment.PaymentDate,
                RateValueType = fgtsPayment.RateValueType, 
                Description = fgtsPayment.Description, 
                Identifier = fgtsPayment.Identifier,
                FromBank = account.Bank,
                FromBankBranch = account.BankBranch,
                FromBankAccount = account.BankAccount,
                FromBankAccountDigit = account.BankAccountDigit
            };
        }

        public IntegrationRequest.DARJPaymentRequest Map(DARJPayment darjPayment, Account account, IEnumerable<OperationTag> operationTags)
        {
            return new IntegrationRequest.DARJPaymentRequest
            {
                AccountId = darjPayment.AccountId,
                TaxId = darjPayment.TaxId,
                ContributorTaxId = darjPayment.ContributorTaxId,
                ReferenceNumber = darjPayment.ReferenceNumber,
                PrincipalValue = darjPayment.PrincipalValue,
                FineValue = darjPayment.FineValue,
                InterestValue = darjPayment.InterestValue,
                MonetaryValue = darjPayment.MonetaryValue,
                TotalValue = darjPayment.TotalValue,
                RateValue = darjPayment.RateValue,
                DueDate = darjPayment.DueDate,
                PaymentDate = darjPayment.PaymentDate,
                Tags = operationTags.Select((OperationTag) => OperationTag.Tag).ToList(),
                CodeRevenue = darjPayment.CodeRevenue,
                StateRegistration = darjPayment.StateRegistration,
                OriginDocument = darjPayment.OriginDocument,
                RateValueType = darjPayment.RateValueType,
                Description = darjPayment.Description,
                Identifier = darjPayment.Identifier,
                FromBank = account.Bank,
                FromBankBranch = account.BankBranch,
                FromBankAccount = account.BankAccount,
                FromBankAccountDigit = account.BankAccountDigit
            };
        }

        public IntegrationRequest.GAREPaymentRequest Map(GAREPayment garePayment, Account account, IEnumerable<OperationTag> operationTags)
        {
            return new IntegrationRequest.GAREPaymentRequest
            {
                AccountId = garePayment.AccountId,
                TaxId = garePayment.TaxId,
                ContributorTaxId = garePayment.ContributorTaxId,
                ReferenceNumber = garePayment.ReferenceNumber,
                PrincipalValue = garePayment.PrincipalValue,
                FineValue = garePayment.FineValue,
                InterestValue = garePayment.InterestValue,
                TotalValue = garePayment.TotalValue,
                RateValue = garePayment.RateValue,
                DueDate = garePayment.DueDate,
                PaymentDate = garePayment.PaymentDate,
                Tags = operationTags.Select((OperationTag) => OperationTag.Tag).ToList(),
                CodeRevenue = garePayment.CodeRevenue,
                StateRegistration = garePayment.StateRegistration,
                ActiveDebit = garePayment.ActiveDebit,
                QuoteNumberNotification = garePayment.QuoteNumberNotification,
                RateValueType = garePayment.RateValueType,
                Description = garePayment.Description,
                Identifier = garePayment.Identifier,
                GAREType = garePayment.GAREType,
                FromBank = account.Bank,
                FromBankBranch = account.BankBranch,
                FromBankAccount = account.BankAccount,
                FromBankAccountDigit = account.BankAccountDigit
            };
        }
    }
}