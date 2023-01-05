using Osb.Core.Platform.Auth.Entity.Models;

namespace Osb.Core.Platform.Auth.Repository.Interfaces
{
    public interface IAuthRepository
    {
        UserCredential GetUserCredentialByUserId(long? userId);
        RememberLoginToken SaveTaxIdToken(long? userId, long? companyId, string hashTokenAccess, string tokenAccess);
        RememberLoginToken UpdateTokenAccess(long? userId, long? companyId, string hashTokenAccess, string tokenAccess);
    }
}