namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class UserCredentialRequest
    {
        public long UserCredential { get; set; }
        public long UserId { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}