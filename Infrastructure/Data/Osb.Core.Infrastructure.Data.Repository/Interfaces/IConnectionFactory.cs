using System.Data;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Infrastructure.Data.Repository.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
        TransactionScope CreateTransaction();
    }
}