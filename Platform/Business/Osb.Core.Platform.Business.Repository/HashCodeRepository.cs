using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Repository.Interfaces;


namespace Osb.Core.Platform.Business.Repository
{
    public class HashCodeRepository : IHashCodeRepository
    {
        private readonly IDbContext<HashCode> _context;

        public HashCodeRepository(IDbContext<HashCode> context)
        {
            this._context = context;
        }

        public void Save(HashCode saveHashCode)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramHashCode"] = saveHashCode.Value,
                ["paramUserId"] = saveHashCode.CreationUserId
            };

            _context.ExecuteWithNoResult("InsertHashCode", parameters);
        }
    }
}