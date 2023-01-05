using System;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Request
{
    public class FindExpectedBoletoPaymentDateRequest : BaseRequest
    {
        public new string Method { get => "ExpectedDatePayment"; }
        public DateTime ActualDatePayment { get; set; }
        public string BarCode { get; set; }
    }
}