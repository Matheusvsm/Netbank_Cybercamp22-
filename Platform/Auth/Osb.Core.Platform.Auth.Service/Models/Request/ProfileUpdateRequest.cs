using System.Collections.Generic;

namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class ProfileUpdateRequest : BaseRequest
    {
        public long ProfileId { get; set; }
        public string Name { get; set; }
        public List<long> ActionFunctions { get; set; }
    }
}