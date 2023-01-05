using System.Data;

namespace Osb.Core.Platform.Common.Entity
{
    public class TransactionScope
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        public bool IsUnique { get; set; }
    }
}