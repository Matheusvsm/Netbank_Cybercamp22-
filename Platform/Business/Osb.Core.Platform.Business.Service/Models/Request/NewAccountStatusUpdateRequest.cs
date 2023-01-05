using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class UpdateNewAccountStatusRequest
    {
        public long NewAccountId { get; set; }
        public NewAccountStatus Status { get; set; }
    }
}