using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class ResetPasswordRequest
    {
        public string Login { get; set; }
        public long CompanyId { get; set; }
        public SendType SendType { get; set; }
    }
}