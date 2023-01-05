using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindPendingInternalTransferResponse
    {
        public string Message { get; set; }
        public decimal TransferValue { get; set; }
        public string PhoneNumber { get; set; }
        public List<long> PendingInternalTransferIds { get; set; }
    }
}