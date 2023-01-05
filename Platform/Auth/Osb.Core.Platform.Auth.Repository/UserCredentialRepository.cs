using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Common.Entity;

namespace Osb.Core.Platform.Auth.Repository
{
    public class UserCredentialRepository : IUserCredentialRepository
    {
        private IDbContext<UserCredential> _context;

        public UserCredentialRepository(IDbContext<UserCredential> context)
        {
            _context = context;
        }

        public UserCredential GetUserCredentialByUserId(long? userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId
            };

            UserCredential userCredential = _context.ExecuteWithSingleResult("GetUserCredentialByUserId", parameters);

            return userCredential;
        }

        public void Save(UserCredential userCredential, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userCredential.UserId,
                ["paramPassword"] = userCredential.Password,
                ["paramSalt"] = userCredential.Salt
            };

            _context.ExecuteWithNoResult("InsertUserCredential", parameters, transactionScope);
        }

        public void Update(UserCredential userCredential, TransactionScope transactionScope = null)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserCredentialId"] = userCredential.UserCredentialId,
                ["paramUpdateUserId"] = userCredential.UserId,
                ["paramDeletionDate"] = userCredential.DeletionDate
            };

            _context.ExecuteWithNoResult("UpdateUserCredential", parameters, transactionScope);
        }
    }
}