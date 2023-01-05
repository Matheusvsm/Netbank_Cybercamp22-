using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindTopUpProductListByPhoneNumberResponse
    {
        public IEnumerable<TopUpProduct> Products { get; set; }
        public string OriginNSU { get; set; }
    }
}