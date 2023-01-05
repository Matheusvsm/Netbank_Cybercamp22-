using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class CancelFuturePaymentRequest : BaseRequest
    {
        public new string Method { get; set; }
        public long ExternalIdentifier { get; set; }
    }
}