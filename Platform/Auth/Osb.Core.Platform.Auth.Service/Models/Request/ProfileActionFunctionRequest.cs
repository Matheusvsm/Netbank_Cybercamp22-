using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class ProfileActionFunctionRequest : BaseRequest
    {
        public long ProfileId { get; set; }
        public long ActionFunctionId { get; set; }
    }
}