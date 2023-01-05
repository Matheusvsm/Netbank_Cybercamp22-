using Osb.Core.Platform.Integration.Entity.Fitbank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Fitbank.Models.Response;

namespace Osb.Core.Platform.Integration.Service.Fitbank.Interfaces
{
    public interface INewAccountService
    {
        NewAccountResponse NewAccount(NewAccountRequest newAccountRequest);
    }
}