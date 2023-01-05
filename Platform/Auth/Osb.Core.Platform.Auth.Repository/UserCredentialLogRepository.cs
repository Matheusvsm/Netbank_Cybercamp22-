using System;
using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Repository
{
    public class UserCredentialLogRepository : IUserCredentialLogRepository
    {
        private IDbContext<UserCredentialLog> _context;

        public UserCredentialLogRepository(IDbContext<UserCredentialLog> context)
        {
            _context = context;
        }

        public void Save(string login, long? UserId)

        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramLogin"] = login,
                ["paramUserId"] = UserId
            };

            _context.ExecuteWithNoResult("InsertUserCredentialLog", parameters);
        }

    }
}