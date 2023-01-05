using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class ProfileRequest : BaseRequest
    {
        public string Name { get; set; }
        public List<long> ActionFunctions { get; set; }
    }
}