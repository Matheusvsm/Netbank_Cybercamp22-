using System.Collections.Generic;
namespace Osb.Core.Api.Application.Models.Request
{
    public class CancelTopUpPeriodicRequest : BaseRequest
    {
        public IEnumerable<TopUpRequest> TopUps {get; set;}
    }
}