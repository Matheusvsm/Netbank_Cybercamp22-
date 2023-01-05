using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class RegisterDeviceRequest : BaseRequest
    {
        public string Token { get; set; }
    }
}