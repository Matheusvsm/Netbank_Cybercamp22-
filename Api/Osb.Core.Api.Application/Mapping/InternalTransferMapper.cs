using Osb.Core.Api.Application.Models.Request;
using Osb.Core.Api.Application.Util;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class InternalTransferMapper
    {
        public BusinessRequest.InternalTransferRequest Map(InternalTransferRequest internalTransferRequest)
        {
            return new BusinessRequest.InternalTransferRequest
            {
                AccountId = internalTransferRequest.AccountId,
                UserId = internalTransferRequest.UserId,
                ToTaxId = Formatter.RemoveMaskFromTaxId(internalTransferRequest.ToTaxId),
                AccountKey = internalTransferRequest.AccountKey,
                TransferValue = internalTransferRequest.TransferValue,
                TransferDate = internalTransferRequest.TransferDate,
                Tags = internalTransferRequest.Tags,
                Description = internalTransferRequest.Description,
                Bank = internalTransferRequest.Bank,
                BankBranch = internalTransferRequest.BankBranch,
                BankAccount = internalTransferRequest.BankAccount,
                BankAccountDigit = internalTransferRequest.BankAccountDigit,
                Attachments = internalTransferRequest.Attachments
            };
        }

        public BusinessRequest.FindPendingInternalTransferRequest Map(FindPendingInternalTransferRequest getPendingInternalTransferRequest, object companyId)
        {
            var taxId = getPendingInternalTransferRequest.TaxId;

            return new BusinessRequest.FindPendingInternalTransferRequest
            {
                CompanyId = (long)companyId,
                Name = getPendingInternalTransferRequest.Name,
                TaxId = taxId != null ? Formatter.RemoveMaskFromTaxId(taxId) : string.Empty,
                VerificationCode = getPendingInternalTransferRequest.VerificationCode,
                PhoneNumber = getPendingInternalTransferRequest.PhoneNumber,
                UserId = getPendingInternalTransferRequest.UserId
            };
        }

        public BusinessRequest.UpdateInternalTransferRequest Map(UpdateInternalTransferRequest updateInternalTransferRequest)
        {
            return new BusinessRequest.UpdateInternalTransferRequest
            {
                InternalTransferId = updateInternalTransferRequest.InternalTransferId,
                Status = updateInternalTransferRequest.Status,
                UserId = updateInternalTransferRequest.UserId,
                AccountId = updateInternalTransferRequest.AccountId
            };
        }

        public BusinessRequest.PendingInternalTransferRequest Map(PendingInternalTransferRequest pendingInternalTransferBySMSRequest)
        {
            return new BusinessRequest.PendingInternalTransferRequest
            {
                UserId = pendingInternalTransferBySMSRequest.UserId,
                AccountId = pendingInternalTransferBySMSRequest.AccountId,
                PhoneNumber = Formatter.RemoveMaskFromPhoneNumber(pendingInternalTransferBySMSRequest.PhoneNumber),
                CountryCode = "55",
                Value = pendingInternalTransferBySMSRequest.Value
            };
        }
    }
}