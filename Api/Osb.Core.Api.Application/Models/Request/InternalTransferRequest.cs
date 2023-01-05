using System;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Api.Application.Models.Request
{
    public class InternalTransferRequest : BaseRequest
    { 
        public string ToTaxId { get; set; }
        public string AccountKey { get; set; }
        public decimal TransferValue { get; set; }
        public DateTime TransferDate { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}