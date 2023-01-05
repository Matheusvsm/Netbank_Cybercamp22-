using System;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindExpectedTransferDateRequest : BaseRequest
    {
        public new string Method { get => "ExpectedDateTransfer"; }
        public DateTime ActualDateTransfer { get; set; }
        public string BankCode { get; set; }
        public string AccountType { get; set; }
        public bool? CustomFormatDate { get; set; }

    }
}