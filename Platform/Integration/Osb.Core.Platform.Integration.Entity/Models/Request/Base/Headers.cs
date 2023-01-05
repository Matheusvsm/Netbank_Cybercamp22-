using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.Models.Request.Auth;

namespace Osb.Core.Platform.Integration.Entity.Models.Request.Base
{
    public class Headers
    {
        public Authorization Authorization { get; set; }
        public IDictionary<string, string> Others { get; set; } = new Dictionary<string, string>();
    }
}