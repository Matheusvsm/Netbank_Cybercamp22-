using System;
using System.Text.Json.Serialization;
using Osb.Core.Api.Application.Util;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindExpectedTransferDateRequest : BaseRequest
    {
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ActualTransferDate { get; set; }
        public string BankCode { get; set; }
        public string AccountType { get; set; }
        public bool? CustomFormatDate { get; set; }
    }
}