namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class ChangePasswordRequest
    {
        public long UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmationNewPassword { get; set; }
    }
}