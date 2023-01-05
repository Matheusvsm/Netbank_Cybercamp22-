using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class TopUpMapper : Mapper
    {
        public ExternalRequest Map(
            CompanyAuthentication companyAuthentication,
            FindTopUpProductListRequest findTopUpProductListRequest)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findTopUpProductListRequest.Headers
            );
            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findTopUpProductListRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    ProductType = findTopUpProductListRequest.ProductType,
                    ProductSubType = findTopUpProductListRequest.ProductSubType,
                    ProductValue = findTopUpProductListRequest.ProductValue
                }
            };
        }

        public ExternalRequest Map(
            TopUpAuthorizeRequest getTopUpAuthorizeRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                getTopUpAuthorizeRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = getTopUpAuthorizeRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    DocumentNumber = getTopUpAuthorizeRequest.ExternalIdentifier,
                    OriginNSU = getTopUpAuthorizeRequest.OriginNSU
                }
            };
        }

        public ExternalRequest Map(
            GenerateTopUpRequest topUpRequest,
            CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                topUpRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = topUpRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    ProductType = topUpRequest.ProductType,
                    BatchIdentifier = topUpRequest.BatchIdentifier,
                    ProductKey = topUpRequest.ProductKey,
                    ProductValue = topUpRequest.ProductValue,
                    ContractIdentifier = topUpRequest.ContractIdentifier,
                    OriginNSU = topUpRequest.OriginNSU,
                    TaxNumber = topUpRequest.TaxNumber,
                    FromBank = topUpRequest.FromBank,
                    FromBankBranch = topUpRequest.FromBankBranch,
                    FromBankAccount = topUpRequest.FromBankAccount,
                    FromBankAccountDigit = topUpRequest.FromBankAccountDigit,
                    Tags = topUpRequest.Tags
                }
            };
        }

        public ExternalRequest Map(
           FindTopUpProductListByPhoneNumberRequest findTopUpByPhoneNumberRequest,
           CompanyAuthentication companyAuthentication)
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findTopUpByPhoneNumberRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findTopUpByPhoneNumberRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    Phone = findTopUpByPhoneNumberRequest.PhoneNumber,
                    ProductSubType = findTopUpByPhoneNumberRequest.ProductSubType
                }
            };
        }
    }
}