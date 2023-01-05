using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindTopUpProductListByPhoneNumberResult
    {
        public string OriginNSU { get; set; }
        public IEnumerable<TopUpProduct> TopUpPhoneNumberList { get; set; }
    }
}