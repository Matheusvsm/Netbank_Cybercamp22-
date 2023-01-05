using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Infrastructure.Data.Repository.Interfaces
{
    public interface IDbContext<T> where T : BaseEntity
    {
        IEnumerable<T> ExecuteWithMultipleResults(string procName, IDictionary<string, dynamic> parameters, TransactionScope transactionScope = null);
        T ExecuteWithSingleResult(string procName, IDictionary<string, dynamic> parameters, TransactionScope transactionScope = null);
        void ExecuteWithNoResult(string procName, IDictionary<string, dynamic> parameters, TransactionScope transactionScope = null);
    }
}