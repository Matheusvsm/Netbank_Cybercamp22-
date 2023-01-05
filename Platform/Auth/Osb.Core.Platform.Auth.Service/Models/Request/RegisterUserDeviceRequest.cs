namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class RegisterUserDeviceRequest : BaseRequest
    {
        public string Token { get; set; }
        public long CompanyId { get; set; }
    }
}