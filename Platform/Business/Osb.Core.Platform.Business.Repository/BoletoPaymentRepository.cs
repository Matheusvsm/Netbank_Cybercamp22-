using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Repository
{
    public class BoletoPaymentRepository : IBoletoPaymentRepository
    {
        private readonly IDbContext<BoletoPayment> _context;
        private readonly IDbContext<ScanLicenseKey> _licenseKeyContext;

        public BoletoPaymentRepository(IDbContext<BoletoPayment> context, IDbContext<ScanLicenseKey> licenseKeyContext)
        {
            this._context = context;
            this._licenseKeyContext = licenseKeyContext;
        }

        public void Save(BoletoPayment boletoPayment, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramAccountId"] = boletoPayment.AccountId,
                ["paramName"] = boletoPayment.Name,
                ["paramTaxId"] = boletoPayment.TaxId,
                ["paramReceiverName"] = boletoPayment.ReceiverName,
                ["paramReceiverTaxId"] = boletoPayment.ReceiverTaxId,
                ["paramPayerName"] = boletoPayment.PayerName,
                ["paramPayerTaxId"] = boletoPayment.PayerTaxId,
                ["paramOperationId"] = boletoPayment.OperationId,
                ["paramStatus"] = boletoPayment.Status,
                ["paramBarcode"] = boletoPayment.Barcode,
                ["paramPaymentValue"] = boletoPayment.PaymentValue,
                ["paramPaymentDate"] = boletoPayment.PaymentDate,
                ["paramDueDate"] = boletoPayment.DueDate,
                ["paramDiscountValue"] = boletoPayment.DiscountValue,
                ["paramDescription"] = boletoPayment.Description,
                ["paramIdentifier"] = boletoPayment.Identifier,
                ["paramUserId"] = boletoPayment.CreationUserId,
            };

            _context.ExecuteWithNoResult("InsertBoletoPayment", parameters, transactionScope);
        }

        public BoletoPayment GetById(long boletoPaymentId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = boletoPaymentId
            };

            BoletoPayment boletoPayment = _context.ExecuteWithSingleResult("GetBoletoPaymentById", parameters);

            return boletoPayment;
        }

        public BoletoPayment GetByExternalIdentifier(long externalIdentifier)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramExternalIdentifier"] = externalIdentifier
            };

            BoletoPayment boletoPayment = _context.ExecuteWithSingleResult("GetBoletoPaymentByExternalIdentifier", parameters);
            return boletoPayment;
        }

        public IEnumerable<BoletoPayment> GetListByStatus(BoletoPaymentStatus status)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramStatus"] = status
            };

            IEnumerable<BoletoPayment> boletoPayments = _context.ExecuteWithMultipleResults("GetBoletoPaymentByStatus", parameters);

            return boletoPayments;
        }

        public void Update(BoletoPayment boletoPayment)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = boletoPayment.BoletoPaymentId,
                ["paramExternalIdentifier"] = boletoPayment.ExternalIdentifier,
                ["paramResponseMessage"] = boletoPayment.ResponseMessage,
                ["paramAttempts"] = boletoPayment.Attempts,
                ["paramStatus"] = boletoPayment.Status,
                ["paramUpdateUserId"] = boletoPayment.UpdateUserId
            };

            _context.ExecuteWithNoResult("UpdateBoletoPayment", parameters);
        }

        public ScanLicenseKey GetScanLicenseKeyByCompanyId(long companyId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramCompanyId"] = companyId
            };

            ScanLicenseKey result = _licenseKeyContext.ExecuteWithSingleResult("GetScanLicenseKeyByCompanyId", parameters);

            return result;
        }
    }
}