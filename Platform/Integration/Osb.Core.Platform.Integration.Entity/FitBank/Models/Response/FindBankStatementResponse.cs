using System.Collections.Generic;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindBankStatementResponse
    {
        public IEnumerable<Transaction> Transactions { get; set; }

        public static FindBankStatementResponse Create(IEnumerable<Transaction> Transactions)
        {
            return new FindBankStatementResponse
            {
                Transactions = Transactions
            };
        }
    }
}