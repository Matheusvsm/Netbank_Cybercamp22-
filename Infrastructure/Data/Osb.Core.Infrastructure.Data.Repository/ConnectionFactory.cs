using System.Data;
using Npgsql;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Infrastructure.Data.Repository
{
    public class ConnectionFactory : Interfaces.IConnectionFactory
    {
        private Settings _settings;

        public ConnectionFactory(Settings settings)
        {
            _settings = settings;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new NpgsqlConnection(_settings.ConnectionStrings["core"]);
            return connection;
        }

        public TransactionScope CreateTransaction()
        {
            TransactionScope transactionScope = new TransactionScope();

            transactionScope.Connection = CreateConnection();
            transactionScope.Connection.Open();
            transactionScope.Transaction = transactionScope.Connection.BeginTransaction();

            return transactionScope;
        }
    }
}
