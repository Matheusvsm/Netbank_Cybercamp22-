using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models
{
    public class TopUpProduct
    {
        public string ProductKey { get; set; }
        public string BatchIdentifier { get; set; }
        public TopUpType ProductType { get; set; }
        public TopUpProductSubType ProductSubType { get; set; }
        public TopUpProductValueType ProductValueType { get; set; }
        public decimal ProductValue { get; set; }
        public decimal ProductMinValue { get; set; }
        public decimal ProductMaxValue { get; set; }
        public string Description { get; set; }
    }
}
