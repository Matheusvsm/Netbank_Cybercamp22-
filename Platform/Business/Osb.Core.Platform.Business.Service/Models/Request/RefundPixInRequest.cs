using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class RefundPixInRequest : BaseRequest
    {
        public string ToTaxId { get; set; }
        public string ToName { get; set; }
        public string ToBank { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public decimal RefundValue { get; set; }
        public string CustomerMessage { get; set; }
        public long DocumentNumber { get; set; }
        public List<string> Tags { get; set; }
    }
}