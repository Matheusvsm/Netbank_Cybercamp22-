using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Service.Models.Request
{
    public class ActionFunctionRequest : BaseRequest
    {
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}