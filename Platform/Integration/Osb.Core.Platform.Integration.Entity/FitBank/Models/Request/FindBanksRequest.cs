using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindBanksRequest : BaseRequest
    {
        public new string Method { get => "GetBanks"; }
    }
}