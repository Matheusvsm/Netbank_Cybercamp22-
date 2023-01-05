using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateBoletoPaymentStatusRequest : BaseRequest
    {
        public long? ExternalIdentifier { get; set; }
        public BoletoPaymentStatus Status { get; set; }
    }
}