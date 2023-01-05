using System.Collections.Generic;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private IDbContext<UserCredential> _context;
        private IDbContext<RememberLoginToken> _rememberLoginTokenContext;

        public AuthRepository(IDbContext<UserCredential> context, IDbContext<RememberLoginToken> rememberLoginTokenContext)
        {
            _context = context;
            _rememberLoginTokenContext = rememberLoginTokenContext;
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

        public RememberLoginToken SaveTaxIdToken(long? userId, long? companyId, string hashTokenAccess, string tokenAccess)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId,
                ["paramCompanyId"] = companyId,
                ["paramHashTokenAccess"] = hashTokenAccess,
                ["paramTokenAccess"] = tokenAccess
            };

            RememberLoginToken rememberLoginToken = _rememberLoginTokenContext.ExecuteWithSingleResult("InsertRememberLoginToken", parameters);

            return rememberLoginToken;
        }

        public RememberLoginToken UpdateTokenAccess(long? userId, long? companyId, string hashTokenAccess, string tokenAccess)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId,
                ["paramCompanyId"] = companyId,
                ["paramHashTokenAccess"] = hashTokenAccess,
                ["paramTokenAccess"] = tokenAccess,
            };

            RememberLoginToken rememberLoginToken = _rememberLoginTokenContext.ExecuteWithSingleResult("UpdateRememberLoginToken", parameters);

            return rememberLoginToken;
        }
    }
}