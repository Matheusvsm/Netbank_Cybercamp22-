using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class TaxPaymentRepository : ITaxPaymentRepository
    {
        private readonly IDbContext<FGTSPayment> _fgtsContext;
        private readonly IDbContext<DARJPayment> _darjContext;
        private readonly IDbContext<GAREPayment> _gareContext;

        public TaxPaymentRepository(IDbContext<FGTSPayment> fgtsContext, IDbContext<DARJPayment> darjContext, IDbContext<GAREPayment> gareContext)
        {
            _fgtsContext = fgtsContext;
            _darjContext = darjContext;
            _gareContext = gareContext;
        }

        public void Save(FGTSPayment fgtsPayment, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = fgtsPayment.AccountId,
                ["paramOperationId"] = fgtsPayment.OperationId,
                ["paramTaxId"] = fgtsPayment.TaxId,
                ["paramContributorTaxId"] = fgtsPayment.ContributorTaxId,
                ["paramPrincipalValue"] = fgtsPayment.PrincipalValue,
                ["paramCodeRevenue"] = fgtsPayment.CodeRevenue,
                ["paramBarcode"] = fgtsPayment.Barcode,
                ["paramFGTSIdentifier"] = fgtsPayment.FGTSIdentifier,
                ["paramSocialConnectivityCode"] = fgtsPayment.SocialConnectivityCode,
                ["paramSocialConnectivityDigit"] = fgtsPayment.SocialConnectivityDigit,
                ["paramPaymentDate"] = fgtsPayment.PaymentDate,
                ["paramRateValueType"] = fgtsPayment.RateValueType,
                ["paramStatus"] = fgtsPayment.Status,
                ["paramDescription"] = fgtsPayment.Description,
                ["paramIdentifier"] = fgtsPayment.Identifier,
                ["paramUserId"] = fgtsPayment.CreationUserId
            };

            _fgtsContext.ExecuteWithNoResult("insertfgtspayment", parameters, transactionScope);
        }

        public void Update(FGTSPayment fgtsPayment)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramFGTSPaymentId"] = fgtsPayment.FGTSPaymentId,
                ["paramExternalIdentifier"] = fgtsPayment.ExternalIdentifier,
                ["paramStatus"] = fgtsPayment.Status,
                ["paramAttempts"] = fgtsPayment.Attempts,
                ["paramUpdateUserId"] = fgtsPayment.UpdateUserId
            };

            _fgtsContext.ExecuteWithNoResult("updatefgtspayment", parameters);
        }

        public IEnumerable<FGTSPayment> GetListByStatus(FGTSPaymentStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            IEnumerable<FGTSPayment> FGTSPaymentList = _fgtsContext.ExecuteWithMultipleResults("getfgtspaymentbystatus", parameters);

            return FGTSPaymentList;
        }

        public void Save(DARJPayment darjPayment, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = darjPayment.AccountId,
                ["paramOperationId"] = darjPayment.OperationId,
                ["paramTaxId"] = darjPayment.TaxId,
                ["paramContributorTaxId"] = darjPayment.ContributorTaxId,
                ["paramReferenceNumber"] = darjPayment.ReferenceNumber,
                ["paramPrincipalValue"] = darjPayment.PrincipalValue,
                ["paramFineValue"] = darjPayment.FineValue,
                ["paramInterestValue"] = darjPayment.InterestValue,
                ["paramMonetaryValue"] = darjPayment.MonetaryValue,
                ["paramTotalValue"] = darjPayment.TotalValue,
                ["paramRateValue"] = darjPayment.RateValue,
                ["paramDueDate"] = darjPayment.DueDate,
                ["paramCodeRevenue"] = darjPayment.CodeRevenue,
                ["paramStateRegistration"] = darjPayment.StateRegistration,
                ["paramOriginDocument"] = darjPayment.OriginDocument,
                ["paramPaymentDate"] = darjPayment.PaymentDate,
                ["paramRateValueType"] = darjPayment.RateValueType,
                ["paramDescription"] = darjPayment.Description,
                ["paramIdentifier"] = darjPayment.Identifier,
                ["paramStatus"] = darjPayment.Status,
                ["paramUserId"] = darjPayment.CreationUserId
            };

            _darjContext.ExecuteWithNoResult("InsertDarjPayment", parameters, transactionScope);
        }

        public IEnumerable<DARJPayment> GetDARJPaymentListByStatus(DARJPaymentStatus darjPaymentStatus)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = darjPaymentStatus
            };

            IEnumerable<DARJPayment> darjPayments = _darjContext.ExecuteWithMultipleResults("GetDARJPaymentByStatus", parameters);
            
            return darjPayments;
        }

        public void Update(DARJPayment darjPayment)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramDARJPaymentId"] = darjPayment.DARJPaymentId,
                ["paramExternalIdentifier"] = darjPayment.ExternalIdentifier,
                ["paramStatus"] = darjPayment.Status,
                ["paramAttempts"] = darjPayment.Attempts,
                ["paramUpdateUserId"] = darjPayment.UpdateUserId
            };

            _darjContext.ExecuteWithNoResult("UpdateDARJPayment", parameters);
        }

        public void Save(GAREPayment garePayment, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = garePayment.AccountId,
                ["paramOperationId"] = garePayment.OperationId,
                ["paramTaxId"] = garePayment.TaxId,
                ["paramContributorTaxId"] = garePayment.ContributorTaxId,
                ["paramReferenceNumber"] = garePayment.ReferenceNumber,
                ["paramPrincipalValue"] = garePayment.PrincipalValue,
                ["paramFineValue"] = garePayment.FineValue,
                ["paramInterestValue"] = garePayment.InterestValue,
                ["paramTotalValue"] = garePayment.TotalValue,
                ["paramRateValue"] = garePayment.RateValue,
                ["paramDueDate"] = garePayment.DueDate,
                ["paramPaymentDate"] = garePayment.PaymentDate,
                ["paramCodeRevenue"] = garePayment.CodeRevenue,
                ["paramStateRegistration"] = garePayment.StateRegistration,
                ["paramActiveDebit"] = garePayment.ActiveDebit,
                ["paramQuoteNumberNotification"] = garePayment.QuoteNumberNotification,
                ["paramStatus"] = garePayment.Status,
                ["paramRateValueType"] = garePayment.RateValueType,
                ["paramDescription"] = garePayment.Description,
                ["paramIdentifier"] = garePayment.Identifier,
                ["paramGAREType"] = garePayment.GAREType,
                ["paramUserId"] = garePayment.CreationUserId
            };

            _gareContext.ExecuteWithNoResult("InsertGarePayment", parameters, transactionScope);
        }

        public IEnumerable<GAREPayment> GetListByStatus(GAREPaymentStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            IEnumerable<GAREPayment> garePaymentList = _gareContext.ExecuteWithMultipleResults("GetGAREPaymentListByStatus", parameters);

            return garePaymentList;
        }

        public void Update(GAREPayment garePayment)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramGAREPaymentId"] = garePayment.GAREPaymentId,
                ["paramExternalIdentifier"] = garePayment.ExternalIdentifier,
                ["paramStatus"] = garePayment.Status,
                ["paramAttempts"] = garePayment.Attempts,
                ["paramUpdateUserId"] = garePayment.UpdateUserId
            };

            _gareContext.ExecuteWithNoResult("UpdateGAREPayment", parameters);
        }
    }
}