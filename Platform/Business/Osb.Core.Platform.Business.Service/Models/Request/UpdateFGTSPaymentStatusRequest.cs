using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateFGTSPaymentStatusRequest
    {
        public string Identifier {get; set;}
        public FGTSPaymentStatus Status {get; set;}
    }
}