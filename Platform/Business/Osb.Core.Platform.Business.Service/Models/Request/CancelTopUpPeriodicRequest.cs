using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class CancelTopUpPeriodicRequest : BaseRequest
    {
        public IEnumerable<TopUpRequest> TopUps {get; set;}
    }
}