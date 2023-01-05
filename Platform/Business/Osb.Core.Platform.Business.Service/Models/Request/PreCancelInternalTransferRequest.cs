namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class PreCancelInternalTransferRequest : BaseRequest
    {
        public long? ExternalIdentifier { get; set; }
    }
}