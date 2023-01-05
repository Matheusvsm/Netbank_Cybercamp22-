using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindPixKeyListResult
    {
        public IEnumerable<PixKey> PixKeyList { get; set; }
        
    }
}