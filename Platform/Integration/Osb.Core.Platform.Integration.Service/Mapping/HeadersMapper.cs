using System.Collections.Generic;
using Osb.Core.Platform.Integration.Entity.Models.Request.Auth;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Service.Mapping
{
    public static class HeadersMapper
    {
        public static Headers Map(Authorization authorization, IDictionary<string, string> others)
        {
            return new Headers
            {
                Authorization = authorization,
                Others = others
            };
        }
    }
}