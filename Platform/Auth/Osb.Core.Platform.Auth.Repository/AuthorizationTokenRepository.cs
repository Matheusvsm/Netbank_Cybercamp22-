using System;
using System.Collections.Generic;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Infrastructure.Data.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Repository
{
    public class AuthorizationTokenRepository : IAuthorizationTokenRepository
    {
        private IDbContext<AuthorizationToken> _context;

        public AuthorizationTokenRepository(IDbContext<AuthorizationToken> context)
        {
            _context = context;
        }

        public void Save(AuthorizationToken token)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = token.UserId,
                ["paramTaxId"] = token.TaxId,
                ["paramCode"] = token.Code,
                ["paramSalt"] = token.Salt,
                ["paramStatus"] = token.Status,
                ["paramExpirationDate"] = token.ExpirationDate
            };

            _context.ExecuteWithNoResult("InsertAuthorizationToken", parameters);
        }

        public void UnauthorizeTokensByUserId(long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId
            };

            _context.ExecuteWithNoResult("UnauthorizeAuthorizationTokensByUserId", parameters);
        }

        public void UnauthorizeTokensByTaxId(string taxId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramTaxId"] = taxId
            };

            _context.ExecuteWithNoResult("UnauthorizeAuthorizationTokensByTaxId", parameters);
        }

        public AuthorizationToken GetByUserId(long userId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramUserId"] = userId
            };

            AuthorizationToken authorizationToken = _context.ExecuteWithSingleResult("GetAuthorizationTokenByUserId", parameters);

            return authorizationToken;
        }

        public AuthorizationToken GetByTaxId(string taxId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramTaxId"] = taxId
            };

            AuthorizationToken authorizationToken = _context.ExecuteWithSingleResult("GetAuthorizationTokenByTaxId", parameters);

            return authorizationToken;
        }

        public void Update(AuthorizationToken authorizationToken, long updateUserId)
        {
            var parameters = new Dictionary<string, dynamic>
            {
                ["paramId"] = authorizationToken.AuthorizationTokenId,
                ["paramStatus"] = Convert.ToByte(authorizationToken.Status),
                ["paramValidateAttempts"] = authorizationToken.ValidateAttempts,
                ["paramUpdateUserId"] = updateUserId
            };

            _context.ExecuteWithNoResult("UpdateAuthorizationToken", parameters);
        }
    }
}