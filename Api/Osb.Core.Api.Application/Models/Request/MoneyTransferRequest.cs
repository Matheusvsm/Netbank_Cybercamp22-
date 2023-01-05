using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Api.Application.Models.Request
{
    public class MoneyTransferRequest : BaseRequest
    {
        public string ToTaxId { get; set; }
        public string ToName { get; set; }
        public string ToBank { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public decimal TransferValue { get; set; }
        public DateTime TransferDate { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}