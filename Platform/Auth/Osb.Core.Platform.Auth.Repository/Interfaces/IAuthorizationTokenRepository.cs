using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IAuthorizationTokenRepository
    {
        void Save(AuthorizationToken token);
        AuthorizationToken GetByUserId(long userId);
        AuthorizationToken GetByTaxId(string taxId);
        void Update(AuthorizationToken authorizationToken, long updateUserId);
        void UnauthorizeTokensByUserId(long userId);
        void UnauthorizeTokensByTaxId(string taxId);
    }
}