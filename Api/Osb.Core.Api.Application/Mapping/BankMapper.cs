using Osb.Core.Api.Application.Models.Request;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Api.Application.Mapping
{
    public class BankMapper
    {
        public BusinessRequest.FindBanksRequest Map(FindBanksRequest findBanksRequest)
        {
            return new BusinessRequest.FindBanksRequest
            {
                AccountId = findBanksRequest.AccountId,
                UserId = findBanksRequest.UserId
            };
        }

    }
}

