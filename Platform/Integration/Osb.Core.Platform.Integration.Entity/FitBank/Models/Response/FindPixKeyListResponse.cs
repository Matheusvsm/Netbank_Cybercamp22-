using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindPixKeyListResponse : BaseResponse
    {        
        public IEnumerable<PixKey> PixKeys { get; set; }
    }
}