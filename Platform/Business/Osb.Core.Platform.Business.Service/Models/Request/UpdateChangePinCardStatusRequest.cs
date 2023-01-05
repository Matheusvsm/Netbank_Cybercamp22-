using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateChangePinCardStatusRequest
    {
        public string Identifier { get; set; }
        public ChangePinCardStatus Status { get; set; }
    }
}