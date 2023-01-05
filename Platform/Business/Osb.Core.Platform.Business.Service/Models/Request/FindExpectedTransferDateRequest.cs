using System;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindExpectedTransferDateRequest : BaseRequest
    {
        public DateTime ActualDateTransfer { get; set; }
        public string BankCode { get; set; }
        public string AccountType { get; set; }
        public bool? CustomFormatDate { get; set; }
    }
}