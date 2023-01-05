using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Api.Application.Models.Request
{
    public class ResetPasswordRequest
    {
        public string Login { get; set; }
        public SendType SendType { get; set; }
    }
}