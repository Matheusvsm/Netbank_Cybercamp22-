using System.Collections.Generic;
using System.Security.Claims;

namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class CreateApplicationTokenRequest
    {
        public string Key { get; set; }
        public IEnumerable<Claim> AdditionalClaims { get; set; }
    }
}