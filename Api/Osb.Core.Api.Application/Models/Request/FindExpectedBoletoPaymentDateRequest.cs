using System;
using System.Text.Json.Serialization;
using Osb.Core.Api.Application.Util;

namespace Osb.Core.Api.Application.Models.Request
{
    public class FindExpectedBoletoPaymentDateRequest : BaseRequest
    {
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? ActualPaymentDate { get; set; }
        public string Barcode { get; set; }
    }
}