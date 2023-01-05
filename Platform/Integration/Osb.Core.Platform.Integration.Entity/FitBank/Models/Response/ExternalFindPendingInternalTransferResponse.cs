using Osb.Core.Platform.Integration.Entity.Models;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class ExternalFindPendingInternalTransferResponse : BaseResponse
    {
        public GetPendingInternalTransferPayload Payload { get; set; }
    }
}