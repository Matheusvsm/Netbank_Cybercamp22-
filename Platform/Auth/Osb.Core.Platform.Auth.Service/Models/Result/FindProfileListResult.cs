using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Service.Models.Result
{
    public class FindProfileListResult
    {
        public IEnumerable<Profile> ProfileList { get; set; }
    }
}