using Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Platform.Auth.Service.Interfaces
{
    public interface IAuthorizationTokenService
    {
        void GenerateAuthorizationToken(GenerateAuthorizationTokenRequest authorizationTokenRequest);

        void ValidateAuthorizationToken(ValidateAuthorizationTokenRequest validateAuthorizationTokenRequest);

        void GenerateUnauthenticatedAuthorizationToken(GenerateAuthorizationTokenRequest authorizationTokenRequest);
    }
}