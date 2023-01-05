using System.Linq;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Business.Entity.Models;
using BusinessRequest = Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class BankMapper
    {
        public FindBanksRequest Map(BusinessRequest.FindBanksRequest findBanksRequest)
        {
            return new FindBanksRequest
            {
                AccountId = findBanksRequest.AccountId,
                UserId = findBanksRequest.UserId
            };
        }

        public FindBanksResult Map(FindBanksResponse response)
        {
            return new FindBanksResult
            {
                Banks = response.Banks.Select(x => new Bank
                {
                    Code = x.Code,
                    Name = x.Name
                })
            };
        }

    }
}
