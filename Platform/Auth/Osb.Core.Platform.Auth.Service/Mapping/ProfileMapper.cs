using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Service.Models.Result;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class ProfileMapper
    {
        public FindProfileListResult Map(IEnumerable<Profile> ProfileList)
        {
            return new FindProfileListResult
            {
                ProfileList = ProfileList
            };
        }
    }

}