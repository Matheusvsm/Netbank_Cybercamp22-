using System.Collections.Generic;
namespace Osb.Core.Platform.Business.Service.Models.Result
{
    public class DayTransactions
    {
        public int Day { get; set; }
        public string Month { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}