using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindFutureTransactionsListResponse : BaseResponse
    {
        public IEnumerable<FutureTransaction> FutureTransactions { get; set; }

        public static FindFutureTransactionsListResponse Create(IEnumerable<FutureTransaction> FutureTransactions)
        {
            return new FindFutureTransactionsListResponse
            {
                FutureTransactions = FutureTransactions,
            };
        }
    }
}