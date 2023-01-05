using System.Data;
using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity.Models;
using Dapper;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Infrastructure.Data.Repository
{
    public class DbContext<T> : IDbContext<T> where T : BaseEntity
    {
        private IConnectionFactory _connectionFactory;

        public DbContext(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<T> ExecuteWithMultipleResults(string procName, IDictionary<string, dynamic> parameters, TransactionScope transactionScope = null)
        {
            if (transactionScope == null)
            {
                transactionScope = _connectionFactory.CreateTransaction();
                transactionScope.IsUnique = true;
            }

            IEnumerable<T> result = transactionScope.Connection.Query<T>(
                procName,
                parameters,
                transactionScope.Transaction,
                commandType: CommandType.StoredProcedure
            );

            if (transactionScope.IsUnique)
            {
                transactionScope.Transaction.Commit();
                transactionScope.Connection.Close();
            }

            return result;
        }

        public T ExecuteWithSingleResult(string procName, IDictionary<string, dynamic> parameters, TransactionScope transactionScope = null)
        {
            if (transactionScope == null)
            {
                transactionScope = _connectionFactory.CreateTransaction();
                transactionScope.IsUnique = true;
            }

            T result = transactionScope.Connection.QueryFirstOrDefault<T>(
                procName,
                parameters,
                transactionScope.Transaction,
                commandType: CommandType.StoredProcedure
            );

            if (transactionScope.IsUnique)
            {
                transactionScope.Transaction.Commit();
                transactionScope.Connection.Close();
            }

            return result;
        }

        public void ExecuteWithNoResult(string procName, IDictionary<string, dynamic> parameters, TransactionScope transactionScope = null)
        {
            if (transactionScope == null)
            {
                transactionScope = _connectionFactory.CreateTransaction();
                transactionScope.IsUnique = true;
            }

            transactionScope.Connection.Execute(
                procName,
                parameters,
                transactionScope.Transaction,
                commandType: CommandType.StoredProcedure
            );

            if (transactionScope.IsUnique)
            {
                transactionScope.Transaction.Commit();
                transactionScope.Connection.Close();
            }
        }
    }
}