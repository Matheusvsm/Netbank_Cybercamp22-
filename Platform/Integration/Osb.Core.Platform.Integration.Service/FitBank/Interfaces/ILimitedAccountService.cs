using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.Fitbank.Interfaces
{
    public interface ILimitedAccountService
    {
        LimitedAccountResponse LimitedAccount(LimitedAccountRequest limitedAccountRequest);
    }
}