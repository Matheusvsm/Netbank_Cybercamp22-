using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class GenerateAuthorizationTokenRequest
    {
        public long? UserId { get; set; }
        public long? AccountId { get; set; }
        public long? CompanyId { get; set; }
        public string TaxId { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public SendType? SendType { get; set; }
    }
}