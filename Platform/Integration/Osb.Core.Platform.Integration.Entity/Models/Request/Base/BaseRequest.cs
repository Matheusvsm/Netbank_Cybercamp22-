using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.Models.Request.Base
{
    public class BaseRequest
    {
        public string Method { get; set; }
        public long AccountId { get; set; }
        public long CompanyId { get; set; }
        public long UserId { get; set; }
        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>()
        {
            ["x-osb-identifier-header"] = ""
        };
    }
}