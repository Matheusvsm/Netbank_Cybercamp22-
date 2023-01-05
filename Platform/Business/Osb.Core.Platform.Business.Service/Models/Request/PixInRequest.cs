using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class PixInRequest
    {
        public string ToBankNumber { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public string ToTaxNumber { get; set; }
        public decimal Value { get; set; }
        public PixOutStatus Status { get; set; }
    }
}