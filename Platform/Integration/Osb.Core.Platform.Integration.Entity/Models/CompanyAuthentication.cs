using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Integration.Entity.Models
{
    public class CompanyAuthentication : BaseEntity
    {
        public long CompanyAuthenticationId { get; set; }
        public long CompanyId { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}