using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Api.Entity
{
    public class ActionFunction : BaseEntity
    {
        public long ActionFunctionId { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}