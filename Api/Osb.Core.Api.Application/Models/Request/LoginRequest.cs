namespace Osb.Core.Api.Application.Models.Request
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string TokenAccess { get; set; }
        public bool SwitchAlternateState { get; set; }
    }
}