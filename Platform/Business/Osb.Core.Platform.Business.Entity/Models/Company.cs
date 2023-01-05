using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Business.Entity.Models
{
    public class Company : BaseEntity
    { 
        public long CompanyId { get; set; }
        public string Name { get; set; }
    }
}