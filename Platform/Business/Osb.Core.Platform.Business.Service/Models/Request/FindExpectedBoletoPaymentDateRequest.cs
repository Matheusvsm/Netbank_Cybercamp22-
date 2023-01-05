using System;

namespace Osb.Core.Platform.Business.Service.Models.Request
{
    public class FindExpectedBoletoPaymentDateRequest : BaseRequest
    {
        public DateTime? ActualDatePayment { get; set; }
        public string BarCode { get; set; }
    }
}