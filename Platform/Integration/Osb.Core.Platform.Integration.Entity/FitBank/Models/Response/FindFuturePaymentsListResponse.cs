using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindFuturePaymentsListResponse : BaseResponse
    {
        public IEnumerable<FuturePayment> FuturePayments { get; set; }

        public static FindFuturePaymentsListResponse Create(IEnumerable<FuturePayment> FuturePayments)
        {
            return new FindFuturePaymentsListResponse
            {
                FuturePayments = FuturePayments
            };
        }
    }
}