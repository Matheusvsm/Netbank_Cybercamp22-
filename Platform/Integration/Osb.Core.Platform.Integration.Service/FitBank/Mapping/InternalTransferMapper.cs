using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class InternalTransferMapper : Mapper
    {
        public ExternalRequest Map(
            InternalTransferRequest internalTransferRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                internalTransferRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = internalTransferRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    FromTaxNumber = internalTransferRequest.FromTaxNumber,
                    FromBank = internalTransferRequest.FromBank,
                    FromBankBranch = internalTransferRequest.FromBankBranch,
                    FromBankAccount = internalTransferRequest.FromBankAccount,
                    FromBankAccountDigit = internalTransferRequest.FromBankAccountDigit,
                    ToTaxNumber = internalTransferRequest.ToTaxNumber,
                    ToBank = internalTransferRequest.ToBank,
                    ToBankBranch = internalTransferRequest.ToBankBranch,
                    ToBankAccount = internalTransferRequest.ToBankAccount,
                    ToBankAccountDigit = internalTransferRequest.ToBankAccountDigit,
                    Value = internalTransferRequest.Value,
                    TransferDate = internalTransferRequest.TransferDate,
                    Identifier = internalTransferRequest.Identifier,
                    Description = internalTransferRequest.Description,
                    Tags = internalTransferRequest.Tags,
                    RateValueType = 1
                }
            };
        }

        public ExternalRequest Map(
            FindPendingInternalTransferRequest findPendingInternalTransferRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findPendingInternalTransferRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findPendingInternalTransferRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = findPendingInternalTransferRequest.TaxNumber,
                    PhoneNumber = findPendingInternalTransferRequest.PhoneNumber,
                    VerificationCode = findPendingInternalTransferRequest.VerificationCode,
                    Name = findPendingInternalTransferRequest.Name
                }
            };
        }

        public FindPendingInternalTransferResponse Map(
            ExternalFindPendingInternalTransferResponse externalFindPendingInternalTransferResponse)
        {
            return new FindPendingInternalTransferResponse
            {
                Message = externalFindPendingInternalTransferResponse.Message,
                TransferValue = externalFindPendingInternalTransferResponse.Payload.TransferValue,
                PhoneNumber = externalFindPendingInternalTransferResponse.Payload.PhoneNumber,
                PendingInternalTransferIds = externalFindPendingInternalTransferResponse.Payload.PendingInternalTransferIds
            };
        }

        public ExternalRequest Map(
            PendingInternalTransferRequest pendingInternalTransferRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                pendingInternalTransferRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = pendingInternalTransferRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    PhoneNumber = pendingInternalTransferRequest.PhoneNumber,
                    CountryCode = pendingInternalTransferRequest.CountryCode,
                    Value = pendingInternalTransferRequest.Value,
                    Identifier = pendingInternalTransferRequest.Identifier,
                    FromTaxNumber = pendingInternalTransferRequest.FromTaxNumber,
                    FromBank = pendingInternalTransferRequest.FromBank,
                    FromBankBranch = pendingInternalTransferRequest.FromBankBranch,
                    FromBankAccount = pendingInternalTransferRequest.FromBankAccount,
                    FromBankAccountDigit = pendingInternalTransferRequest.FromBankAccountDigit
                }
            };
        }
    }
}