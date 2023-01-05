using System;
using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity.Enums;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class GeneratePixOutRequest : BaseRequest
    {
        public string ToName { get; set; }
        public string ToTaxId { get; set; }
        public string ToBank { get; set; }
        public string ToBankBranch { get; set; }
        public string ToBankAccount { get; set; }
        public string ToBankAccountDigit { get; set; }
        public string ToBankName { get; set; }
        public decimal Value { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<string> Tags { get; set; }
        public string Description { get; set; }
        public string CustomerMessage { get; set; }
        public string PixKey { get; set; }
        public PixKeyType? PixKeyType { get; set; }
        public AccountType AccountType { get; set; }
        public long? SearchProtocol { get; set; }
    }
}