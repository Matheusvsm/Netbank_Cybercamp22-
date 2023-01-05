using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class Application : BaseEntity
    {
        public long ApplicationId { get; set; }
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public string Salt { get; set; }
    }
}