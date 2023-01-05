using System.Text.Json;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Service.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class HashCodeMapper
    {
        public ExternalRequest Map(
            GenerateHashCodeRequest generateHashCodeRequest,
            CompanyAuthentication companyAuthentication
            )
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                generateHashCodeRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = generateHashCodeRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    TaxNumber = generateHashCodeRequest.TaxId,
                    Identifier = generateHashCodeRequest.Identifier,
                    AccountKey = generateHashCodeRequest.AccountKey,
                    Bank = generateHashCodeRequest.Bank,
                    BankBranch = generateHashCodeRequest.BankBranch,
                    BankAccount = generateHashCodeRequest.BankAccount,
                    BankAccountDigit = generateHashCodeRequest.BankAccountDigit,
                    Value = generateHashCodeRequest.Value
                }
            };
        }

        public ExternalRequest Map(
            ReadHashCodeRequest readHashCodeRequest,
            CompanyAuthentication companyAuthentication
            )
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                readHashCodeRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = readHashCodeRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    HashCode = readHashCodeRequest.HashCode
                }
            };
        }

        public T Map<T>(ExternalResponse externalResponse)
        {
            return JsonSerializer.Deserialize<T>(externalResponse.Data);
        }
    }
}