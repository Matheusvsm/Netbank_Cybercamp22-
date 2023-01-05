using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Service.Models.Result;
using Osb.Core.Platform.Auth.Service.Validators;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Mapping;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Util.Resources.AuthExcMsg;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Auth.Common;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Common.Util.Security;
using System.Collections.Generic;

namespace Osb.Core.Platform.Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly AuthValidator _validator;
        private readonly AuthMapper _mapper;
        private readonly IAuthRepositoryFactory _authRepositoryFactory;
        private readonly IUserRepositoryFactory _userRepositoryFactory;
        private readonly IUserCredentialLogRepositoryFactory _userCredentialLogRepositoryFactory;
        private readonly Settings _settings;
        private readonly IApplicationRepository _applicationRepository;

        public AuthService(
            IAuthRepositoryFactory authRepositoryFactory,
            IUserRepositoryFactory userRepositoryFactory,
            IUserCredentialLogRepositoryFactory userCredentialLogRepositoryFactory,
            Settings settings,
            IApplicationRepository applicationRepository)
        {
            _authRepositoryFactory = authRepositoryFactory;
            _userRepositoryFactory = userRepositoryFactory;
            _userCredentialLogRepositoryFactory = userCredentialLogRepositoryFactory;
            _settings = settings;
            _applicationRepository = applicationRepository;
            _validator = new AuthValidator();
            _mapper = new AuthMapper();
        }

        public AuthenticateResult Authenticate(AuthenticateRequest authenticateRequest)
        {
            _validator.Validate(authenticateRequest);

            IUserRepository _userRepository = _userRepositoryFactory.Create();
            IAuthRepository _authRepository = _authRepositoryFactory.Create();

            User user;
            RememberLoginToken rememberLoginToken;
            string tokenAccess = String.Empty;

            if (authenticateRequest.SwitchAlternateState == true && !string.IsNullOrEmpty(authenticateRequest.TokenAccess) && string.IsNullOrEmpty(authenticateRequest.Login))
            {
                user = _userRepository.GetUserByTokenAccessAndCompanyId(authenticateRequest.TokenAccess, authenticateRequest.CompanyId);
                tokenAccess = authenticateRequest.TokenAccess;
            }
            else
                user = _userRepository.GetUserByLoginAndCompanyId(authenticateRequest.Login, authenticateRequest.CompanyId);

            if (user == null)
                throw new OsbAuthException(AuthExcMsg.EXC0018);

            if (user.Status != UserStatus.Active)
                throw new OsbAuthException(AuthExcMsg.EXC0018);

            UserInformation userInformation = _userRepository.GetByUserId(user.UserId);

            UserCredential userCredential = _authRepository.GetUserCredentialByUserId(user.UserId);

            if (userCredential == null)
                throw new OsbAuthException(AuthExcMsg.EXC0005);

            CompareCredential(authenticateRequest, userCredential);

            if ((authenticateRequest.SwitchAlternateState == true) && string.IsNullOrEmpty(authenticateRequest.TokenAccess))
            {
                string hashTokenAccess = SHA512Provider.GenerateSalt();
                tokenAccess = SHA512Provider.Encrypt(authenticateRequest.Login, hashTokenAccess);

                rememberLoginToken = _authRepository.SaveTaxIdToken(user.UserId, authenticateRequest.CompanyId, hashTokenAccess, tokenAccess);
            }

            if (!string.IsNullOrEmpty(authenticateRequest.Login) && authenticateRequest.SwitchAlternateState == true && !string.IsNullOrEmpty(authenticateRequest.TokenAccess))
            {
                string hashTokenAccess = SHA512Provider.GenerateSalt();
                tokenAccess = SHA512Provider.Encrypt(authenticateRequest.Login, hashTokenAccess);

                rememberLoginToken = _authRepository.UpdateTokenAccess(user.UserId, authenticateRequest.CompanyId, hashTokenAccess, tokenAccess);
            }

            string jwtToken = GenerateJwtToken(authenticateRequest, user.UserId.ToString());

            AuthenticateResult authenticateResult = _mapper.Map(user, jwtToken, tokenAccess, userInformation);
            IUserCredentialLogRepository userCredentialLogRepository = _userCredentialLogRepositoryFactory.Create();
            userCredentialLogRepository.Save(user.Login, user.UserId);

            return authenticateResult;
        }

        public string GenerateJwtToken(AuthenticateRequest authenticateRequest, string userId)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(_settings.JwtSecret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, authenticateRequest.Login),
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, "default")
                    //TODO: Adicionar o role quando estivermos trabalhando com profile
                }),
                Expires = DateTime.UtcNow.AddMinutes(_settings.JwtExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private void CompareCredential(AuthenticateRequest request, UserCredential credential)
        {
            bool match = SHA512Provider.Compare(request.Password, credential.Password, credential.Salt);

            IUserRepository _userRepository = _userRepositoryFactory.Create();
            User user = _userRepository.GetById(credential.UserId);

            if (!match)
            {
                user.LoginAttempts += 1;

                if (user.LoginAttempts >= _settings.LoginAttempts)
                {
                    user.Status = UserStatus.Blocked;
                    _userRepository.Update(user);
                    throw new OsbAuthException(AuthExcMsg.EXC0018);
                }

                _userRepository.Update(user);
                throw new OsbAuthException(AuthExcMsg.EXC0018);
            }

            user.LoginAttempts = default(int);
            _userRepository.Update(user);
        }
        public CreateApplicationTokenResult CreateApplicationToken(CreateApplicationTokenRequest request)
        {
            Application application = _applicationRepository.GetApplicationByKey(request.Key);
            if (application is null)
                throw new OsbAuthException(AuthExcMsg.EXC0007);

            var notBefore = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var nonce = Guid.NewGuid().ToString();
            byte[] secret = Encoding.ASCII.GetBytes(application.Secret);
            IEnumerable<Claim> claims = GenerateClaims(request.Key, nonce, additionalClaims: request.AdditionalClaims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(_settings.ApplicationTokenExpirationTime),
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            var result = new CreateApplicationTokenResult
            {
                Token = tokenHandler.WriteToken(token)
            };
            return result;
        }

        private IEnumerable<Claim> GenerateClaims(string app, string nonce, IEnumerable<Claim> additionalClaims = null)
        {
            var claims = new List<Claim>
            {
                new Claim("app", app),
                new Claim("nonce", nonce),
                new Claim(ClaimTypes.Role, "default")
            };
            if (additionalClaims != null)
                claims.AddRange(additionalClaims);

            return claims;
        }
    }
}