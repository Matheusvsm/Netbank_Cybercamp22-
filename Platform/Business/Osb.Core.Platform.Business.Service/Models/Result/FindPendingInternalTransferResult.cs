using System.Collections.Generic;

namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class FindPendingInternalTransferResult
    {
        public string Message { get; set; }
        public decimal TransferValue { get; set; }
        public string PhoneNumber { get; set; }
        public List<long> PendingInternalTransferIds { get; set; }
    }
}