using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class BankValidator
    {
        public void Validate(FindBanksRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException();
        }

    }
}