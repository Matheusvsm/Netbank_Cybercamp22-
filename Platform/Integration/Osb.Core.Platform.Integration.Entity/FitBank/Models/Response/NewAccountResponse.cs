using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Integration.Entity.Fitbank.Models.Response
{
    public class NewAccountResponse : BaseResponse
    {
        public object SpbAccount { get; set; }
        public string AccountKey { get; set; }
        public string Code { get; set; }
    }
}