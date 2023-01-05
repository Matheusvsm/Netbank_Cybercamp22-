using Osb.Core.Platform.Integration.Service.Mapping;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Integration.Service.FitBank.Mapping
{
    public class BankMapper : Mapper
    {
        public ExternalRequest Map(
            FindBanksRequest findBanksRequest,
            CompanyAuthentication companyAuthentication
        )
        {
            Headers headers = HeadersMapper.Map(
                AuthorizationMapper.Map(companyAuthentication),
                findBanksRequest.Headers
            );

            return new ExternalRequest
            {
                Url = companyAuthentication.Url,
                Headers = headers,
                Body = new
                {
                    Method = findBanksRequest.Method,
                    BusinessUnitId = companyAuthentication.CompanyId,
                    PartnerId = companyAuthentication.CompanyAuthenticationId,
                    AccountId = findBanksRequest.AccountId
                }
            };
        }
    }
}